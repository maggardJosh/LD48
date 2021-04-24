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

            List<RaycastHit2D> hitResults = new List<RaycastHit2D>();
            var numHits = Physics2D.Raycast(Owner.transform.position, directionToMove, new ContactFilter2D
            {
                layerMask = Owner.settings.collideMask,
                useLayerMask = true
            }, hitResults);
            if (numHits <= 0)
            {
                Debug.LogError("We didn't hit anything when moving?!");
                return;
            }

            var firstHitResult = hitResults.First();
            
            if (TryHitRock(directionToMove, firstHitResult))
                return;
            if (TryHitGoal(directionToMove, firstHitResult))
                return;
            if (TryHitWall(directionToMove, firstHitResult))
                return;
        }

        private bool TryHitRock(Vector2 directionToMove, RaycastHit2D hit)
        {
            var rock= hit.collider.GetComponent<Rock>();

            if (rock == null)
                return false;
            
            var transitionToPoint = hit.point - directionToMove * .5f;
            if ((transitionToPoint.ToVector3() - Owner.transform.position).sqrMagnitude <= .1f)
            {
                rock.Displace(directionToMove);
                return true;
            }

            Owner.TransitionTo(new MoveState(References, transitionToPoint, _ =>
            {
                rock.Displace(directionToMove.ToVector3());
                return true;
            }));
            return true;
        }

        private bool TryHitGoal(Vector2 directionToMove, RaycastHit2D hit)
        {
           
            var goal= hit.collider.GetComponent<LevelGoal>();

            if (goal == null)
                return false;
            
            var transitionToPoint = hit.point - directionToMove * .5f;
            if ((transitionToPoint.ToVector3() - Owner.transform.position).sqrMagnitude <= .1f)
            {
                return false;
            }

            Owner.TransitionTo(new MoveState(References, transitionToPoint, _ =>
            {
                goal.TransitionToNextLevel();
                GameObject.Destroy(Owner.gameObject);
                return false;
            }));
            return true;
        }

        private bool TryHitWall(Vector2 directionToMove, RaycastHit2D hit)
        {
            var transitionToPoint = hit.point - directionToMove * .5f;
            var isRightNextToWall = (transitionToPoint.ToVector3() - Owner.transform.position).sqrMagnitude <= .1f;
            if (isRightNextToWall)
                return false;

            Owner.TransitionTo(new MoveState(References, transitionToPoint, _ => true));
            return true;
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