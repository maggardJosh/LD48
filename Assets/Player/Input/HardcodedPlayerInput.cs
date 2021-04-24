using UnityEngine;

namespace Player.Input
{
    class HardcodedPlayerInput : IPlayerInput
    {
        public PlayerInput GetInput()
        {
            var moveInput = new Vector2();
            if (UnityEngine.Input.GetKey(KeyCode.D))
                moveInput.x = 1;
            if (UnityEngine.Input.GetKey(KeyCode.A))
                moveInput.x = -1;
            if (UnityEngine.Input.GetKey(KeyCode.W))
                moveInput.y = 1;
            if (UnityEngine.Input.GetKey(KeyCode.S))
                moveInput.y = -1f;
            return new PlayerInput
                {MoveInput = moveInput};
        }
    }
}