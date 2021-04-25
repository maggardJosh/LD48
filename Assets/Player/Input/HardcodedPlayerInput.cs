using UnityEngine;

namespace Player.Input
{
    class HardcodedPlayerInput : IPlayerInput
    {
        private Vector2 _moveInput = Vector2.zero;
        private bool _restartInput = false;
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

            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                _restartInput = true;
            
            var result = new PlayerInput
            {
                MoveInput = _moveInput,
                RestartInput =  _restartInput
            };
            
            _moveInput = Vector2.zero;
            _restartInput = false;
            
            return result;
        }
    }
}