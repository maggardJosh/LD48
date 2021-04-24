using System;
using Player.Input;
using Player.PlayerState;
using UnityEngine;

namespace Player
{
    
    [SelectionBase]
    public class PlayerController : MonoBehaviour
    {
        private readonly IPlayerInput _playerInput = new HardcodedPlayerInput();

        public PlayerSettings settings;

        private PlayerState.PlayerState _state;
        private int _keyCount = 0;
        public PlayerController()
        {
            _state = new IdlePlayerState(new PlayerStateReferences(this));
        }

        private void Start()
        {
            KeyUI.Instance.UpdateKeyCount(_keyCount);
        }

        public void AddKey()
        {
            _keyCount++;
            KeyUI.Instance.UpdateKeyCount(_keyCount);
        }

        public bool UseKey()
        {
            if (_keyCount <= 0)
                return false;
            _keyCount--;
            KeyUI.Instance.UpdateKeyCount(_keyCount);
            return true;
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