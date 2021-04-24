using System.Collections.Generic;
using System.Linq;
using ImportedTools.Extensions;
using Player.Input;
using UnityEngine;

namespace Player.PlayerState
{
    class IdlePlayerState : PlayerState
    {
        public IdlePlayerState(PlayerStateReferences refs) : base(refs)
        {
            
        }
        
        protected override void HandleUpdate(PlayerInput input)
        {
            if (input.MoveInput.sqrMagnitude <= 0.1f)
                return;

            var directionToMove = GetDirectionToMove(input);

            List<RaycastHit2D> results = new List<RaycastHit2D>();
            var numHits = Physics2D.Raycast(Owner.transform.position, directionToMove, new ContactFilter2D
            {
                layerMask = Owner.wallMask,
                useLayerMask = true
            }, results);
            if (numHits <= 0)
            {
                Debug.LogError("We didn't hit any walls??");
                return;
            }

            var transitionToPoint = results.First().point - directionToMove * .5f;
            if ((transitionToPoint.ToVector3() - Owner.transform.position).sqrMagnitude <= .1f)
            {
                Debug.Log("Tried to move but no where to go");
                return;
            }
            Owner.TransitionTo(new MoveState(References, transitionToPoint));
        }

        private static Vector2 GetDirectionToMove(PlayerInput input)
        {
            Vector2 directionToMove = Vector2.zero;
            if (Mathf.Abs(input.MoveInput.x) > 0)
            {
                directionToMove.x = input.MoveInput.x;
            }
            else if (Mathf.Abs(input.MoveInput.y) > 0)
            {
                directionToMove.y = input.MoveInput.y;
            }

            directionToMove.Normalize();
            return directionToMove;
        }
    }
}