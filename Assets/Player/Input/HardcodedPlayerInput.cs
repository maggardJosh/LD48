using UnityEngine;

namespace Player.Input
{
    class HardcodedPlayerInput : IPlayerInput
    {
        private Vector2 _moveInput = Vector2.zero;
        private bool _restartInput = false;

        public PlayerInput GetInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.D) ||
                UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                _moveInput.x = 1;
            if (UnityEngine.Input.GetKeyDown(KeyCode.A) ||
                UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow) ||
                UnityEngine.Input.GetKeyDown(KeyCode.Q))
                _moveInput.x = -1;
            if (UnityEngine.Input.GetKeyDown(KeyCode.W) ||
                UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) ||
                UnityEngine.Input.GetKeyDown(KeyCode.Z))
                _moveInput.y = 1;
            if (UnityEngine.Input.GetKeyDown(KeyCode.S) ||
                UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
                _moveInput.y = -1f;

            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
                _restartInput = true;

            var result = new PlayerInput
            {
                MoveInput = _moveInput,
                RestartInput = _restartInput
            };

            _moveInput = Vector2.zero;
            _restartInput = false;

            return result;
        }
    }
}