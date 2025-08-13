using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private SimpleJoystick _simpleJoystick;
        private Vector2 _move;

        private PlayerMovement _playerMovement;
        private PlayerShoot _playerShoot;
        private TakeControl _takeControl;

        private bool _isShooting = false;
        private bool _isJumpButtonPressed = false;
        private float _horizontalDirection;
        private float _verticalDirection;

        public float HorizontalDirection => _move.x;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerShoot = GetComponent<PlayerShoot>();
            _takeControl = GetComponent<TakeControl>();
            _move.x = 0;
        }

        private void OnEnable()
        {
            _simpleJoystick.ResetInput();
            _move = Vector2.zero;
            _horizontalDirection = 0;
            _verticalDirection = 0;
            _isShooting = false;
            _isJumpButtonPressed = false;

            // Остановим движение
            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }


        private void Update()
        {
            if (_takeControl.ControlOff == false)
            {
                Vector2 input = _simpleJoystick.Direction();
                _move = new Vector2(input.x + _horizontalDirection, 0);
                _horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
                _verticalDirection = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
                //_isShooting = Input.GetButtonDown(GlobalStringVars.SHOOT);
                _isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
                _playerMovement.Move(_move.x, _isJumpButtonPressed, _verticalDirection);
                _playerShoot.Shoot(_isShooting);
                _playerMovement.JumpingDown(_verticalDirection, _isJumpButtonPressed);
            }
        }
    }
}

