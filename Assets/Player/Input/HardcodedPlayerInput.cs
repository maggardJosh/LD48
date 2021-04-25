using UnityEngine;

namespace Player.Input
{
    class HardcodedPlayerInput : IPlayerInput
    {
        private Vector2 _moveInput = Vector2.zero;
        public PlayerInput GetInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                _moveInput.x = 1;
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                _moveInput.x = -1;
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                _moveInput.y = 1;
            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                _moveInput.y = -1f;
            
            var result = new PlayerInput
            {
                MoveInput = _moveInput
            };
            _moveInput = Vector2.zero;
            return result;
        }
    }
}