using System;
using System.Collections.Generic;
using Player.Input;
using UnityEngine;

namespace Player.PlayerState
{
    internal class BeginMoveState : PlayerState
    {
        private readonly Vector2 _transitionToPoint;
        private readonly Vector2 _startPoint;
        private readonly float _dist;
        private readonly Func<PlayerController, bool> _moveCallback;
        private readonly TridentAnimation _tridentAnim;


        public BeginMoveState(PlayerStateReferences references, Vector2 transitionToPoint, Func<PlayerController, bool> moveCallback, Vector2 dir) :
            base(references)
        {
            _startPoint = references.Owner.transform.position;
            _transitionToPoint = transitionToPoint;
            _moveCallback = moveCallback;
            
            _dist = (_startPoint - _transitionToPoint).magnitude;

            _tridentAnim = references.Owner.tridentAnimations.GetObject(dir);
            references.Owner.SetFlipX(dir.x > 0);
        }

        public override void EnterState()
        {
           References.Animator.SetBool("Moving", true);
           _tridentAnim.SetHeight(1);
           _tridentAnim.gameObject.SetActive(true);
        }

        protected override void HandleUpdate(PlayerInput input)
        {
            var t = StateCount / Mathf.Min(Owner.settings.BeginMoveTime * _dist, Owner.settings.MaxBeginMoveTime);
            t = Owner.settings.BeginMoveCurve.Evaluate(t);
            
            _tridentAnim.SetHeight(Mathf.Lerp(0.5f, _dist, t) + .65f);
            
            if (!(t >= 1)) return;

            Owner.TransitionTo(new MoveState(References, _transitionToPoint, _moveCallback, _tridentAnim));
        }
    }
    
    
}