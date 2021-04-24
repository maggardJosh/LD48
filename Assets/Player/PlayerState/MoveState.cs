using Player.Input;
using UnityEngine;

namespace Player.PlayerState
{
    internal class MoveState : PlayerState
    {
        private readonly Vector2 _transitionToPoint;
        private readonly Vector2 _startPoint;
        private readonly float _dist;

        public MoveState(PlayerStateReferences references, Vector2 transitionToPoint) : base(references)
        {
            _startPoint = references.Owner.transform.position;
            _transitionToPoint = transitionToPoint;
            _dist = (_startPoint - _transitionToPoint).magnitude;
        }

        protected override void HandleUpdate(PlayerInput input)
        {
            float t = StateCount / (Owner.settings.MoveTime * _dist);
            t = Owner.settings.MoveCurve.Evaluate(t);
            Owner.transform.position = Vector3.Lerp(_startPoint, _transitionToPoint, t);
            if (t >= 1)
            {
                Owner.transform.position = _transitionToPoint;
                Owner.TransitionTo(new IdlePlayerState(References));
            }
        }
    }
}