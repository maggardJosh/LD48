using Player.Input;
using UnityEngine;

namespace Player.PlayerState
{
    internal class MoveState : PlayerState
    {
        private readonly Vector2 _transitionToPoint;
        private readonly LevelGoal _levelGoal;
        private readonly Vector2 _startPoint;
        private readonly float _dist;

        public MoveState(PlayerStateReferences references, Vector2 transitionToPoint, LevelGoal levelGoal) :
            base(references)
        {
            _startPoint = references.Owner.transform.position;
            _transitionToPoint = transitionToPoint;
            _levelGoal = levelGoal;

            _dist = (_startPoint - _transitionToPoint).magnitude;
        }

        protected override void HandleUpdate(PlayerInput input)
        {
            float t = StateCount / (Owner.settings.MoveTime * _dist);
            t = Owner.settings.MoveCurve.Evaluate(t);
            Owner.transform.position = Vector3.Lerp(_startPoint, _transitionToPoint, t);
            if (t >= 1)
            {
                if (_levelGoal == null)
                {
                    Owner.transform.position = _transitionToPoint;
                    Owner.TransitionTo(new IdlePlayerState(References));
                }
                else
                {
                    _levelGoal.TransitionToNextLevel();
                    GameObject.Destroy(References.Owner.gameObject);
                }
            }
        }
    }
}