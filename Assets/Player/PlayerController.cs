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
        public bool titleMode = false;
        private PlayerState.PlayerState _state;
        private int _keyCount = 0;

        public FourWayTridentAnimationContainer tridentAnimations;
        private SpriteRenderer _srend;

        private void Awake()
        {
            _state = new IdlePlayerState(new PlayerStateReferences(this, GetComponent<Animator>()));

        }

        private void Start()
        {
            KeyUI.Instance.UpdateKeyCount(_keyCount);
            _srend = GetComponentInChildren<SpriteRenderer>();
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
            if (RestartListener.Instance.isTransitioning)
                return;
            
            PlayerInput input = _playerInput.GetInput();

            _state.Update(input);
        }

        private void FixedUpdate()
        {
            _state.FixedUpdate();
        }

        public void SetFlipX(bool flip)
        {
            _srend.flipX = flip;
        }
    }
}