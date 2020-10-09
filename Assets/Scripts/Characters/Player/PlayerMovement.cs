using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        #region Constants

        private const int RUN_MULTIPLIER = 2;

        #endregion

        #region Fields

        public bool IsJump;
        public bool IsRun;
        public bool IsStrafe;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private GroundChecker _groundChecker;
        private InputManager _inputManager;
        private Rigidbody _rigidbody;
        private Vector3 _localMovement;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            if (_rigidbody != null)
            {
                _rigidbody.freezeRotation = true;
            }

            _groundChecker = GetComponentInChildren<GroundChecker>();
            _inputManager = GetComponent<InputManager>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
            CheckJump();
        }

        #endregion


        #region Methods

        private void MovePlayer()
        {
            if (_inputManager.Movement.x != 0 || _inputManager.Movement.z != 0)
            {
                _inputManager.Movement.Normalize();

                if (_inputManager.CheckThatPressedRunButton())
                {
                    IsRun = true;
                    _localMovement = (transform.right * _inputManager.Movement.x + transform.forward * _inputManager.Movement.z) * _speed * RUN_MULTIPLIER;
                }
                else
                {
                    IsRun = false;
                    _localMovement = (transform.right * _inputManager.Movement.x + transform.forward * _inputManager.Movement.z) * _speed;
                }
                transform.position += _localMovement * Time.deltaTime;
                if (_inputManager.Movement.x != 0 && _inputManager.Movement.z == 0)
                {
                    IsStrafe = true;
                }
            }
            else
            {
                IsStrafe = false;
            }
        }

        private void CheckJump()
        {
            if (_inputManager.CheckThatJump() && _groundChecker.IsGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                IsJump = true;
            }
            else if (!_groundChecker.IsGrounded)
            {
                IsJump = true;
            }
            else
            {
                IsJump = false;
            }
        }

        #endregion
    }
}
