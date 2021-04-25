using Player.Input;
using UnityEngine;

namespace Player.PlayerState
{
    public abstract class PlayerState
    {
        protected PlayerStateReferences References;
        protected PlayerController Owner => References.Owner;

        protected PlayerState(PlayerStateReferences references)
        {
            this.References = references;
        }
    
        public virtual void EnterState()
        {
        
        }

        public virtual void ExitState()
        {
        
        }

        
        public void Update(PlayerInput input)
        {
            HandleUpdate(input);
        }

        protected float StateCount = 0;
        public void FixedUpdate()
        {
            StateCount += Time.fixedDeltaTime;
            HandleFixedUpdate();
        }
        protected virtual void HandleUpdate(PlayerInput input){}

        protected virtual void HandleFixedUpdate() { }
    }
}