using UnityEngine;

namespace Player.PlayerState
{
    public class PlayerStateReferences
    {
        public PlayerController Owner { get; }
        public Animator Animator { get; }

        public PlayerStateReferences(PlayerController owner, Animator animator)
        {
            Owner = owner;
            Animator = animator;
        }

    }
}