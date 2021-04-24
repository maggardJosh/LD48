using System;
using System.Collections.Generic;
using Player.Input;
using UnityEngine;

namespace Player.PlayerState
{
    internal class MoveState : PlayerState
    {
        private readonly Vector2 _transitionToPoint;
        private readonly Vector2 _startPoint;
        private readonly float _dist;
        private readonly Func<PlayerController, bool> _moveCallback;

        public MoveState(PlayerStateReferences references, Vector2 transitionToPoint, Func<PlayerController, bool> moveCallback) :
            base(references)
        {
            _startPoint = references.Owner.transform.position;
            _transitionToPoint = transitionToPoint;
            _moveCallback = moveCallback;
            
            _dist = (_startPoint - _transitionToPoint).magnitude;
            List<RaycastHit2D> results = new List<RaycastHit2D>();
            Physics2D.Raycast(_startPoint, (transitionToPoint - _startPoint).normalized, new ContactFilter2D
            {
                layerMask = references.Owner.settings.bubbleMask,
                useLayerMask = true
            }, results, _dist);
            foreach (var hit in results)
            {
                var bubbleComponent = hit.collider.GetComponent<Bubble>();
                if (bubbleComponent != null)
                {
                    bubbleComponent.Collect();
                    Owner.AddKey();
                }
            }
        }
        
        protected override void HandleUpdate(PlayerInput input)
        {
            var t = StateCount / (Owner.settings.MoveTime * _dist);
            t = Owner.settings.MoveCurve.Evaluate(t);
            Owner.transform.position = Vector3.Lerp(_startPoint, _transitionToPoint, t);
            if (!(t >= 1)) return;

            if (_moveCallback != null)
            {
                var shouldTransitionBack = _moveCallback(Owner);
                if (!shouldTransitionBack)
                    return;
            }

            Owner.transform.position = _transitionToPoint;
            Owner.TransitionTo(new IdlePlayerState(References));
        }
    }
}