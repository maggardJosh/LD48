using System;
using Player.Input;
using Player.PlayerState;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private readonly IPlayerInput _playerInput = new HardcodedPlayerInput();
        public LayerMask wallMask;
        public PlayerSettings settings;

        private PlayerState.PlayerState _state;

        public PlayerController()
        {
            _state = new IdlePlayerState(new PlayerStateReferences(this));
        }

        public void TransitionTo(PlayerState.PlayerState newState)
        {
            _state.ExitState();
            _state = newState;
            newState.EnterState();
        }
        void Update()
        {
            PlayerInput input = _playerInput.GetInput();
            _state.Update(input);
        }

        private void FixedUpdate()
        {
            _state.FixedUpdate();
        }
    }
}