using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        #region Constants

        private const int RUN_MULTIPLIER = 2;
        private const float RUN_STAMINA_REDUCE = 0.5f;

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
        private BaseData _playerData;
        private RestoreStamina _restoreStamina;
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
            _playerData = GetComponent<BaseData>();
            _restoreStamina = GetComponent<RestoreStamina>();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void Update()
        {
            CheckJump();
        }

        #endregion


        #region Methods

        private void MovePlayer()
        {
            if (_inputManager.Movement.x != 0 || _inputManager.Movement.z != 0)
            {
                _inputManager.Movement.Normalize();

                if (_inputManager.PressedRunButton() && _playerData.GetStamina() > 0)
                {
                    IsRun = true;
                    _localMovement = (transform.right * _inputManager.Movement.x + transform.forward * _inputManager.Movement.z) * _speed * RUN_MULTIPLIER;
                    _playerData.ReduceStamina(RUN_STAMINA_REDUCE);
                    _restoreStamina.StartRestoreTimer();

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
                else
                {
                    IsStrafe = false;
                }
            }
            else
            {
                IsStrafe = false;
            }
        }

        private void CheckJump()
        {
            if (_inputManager.PressedThatJump() && _groundChecker.IsGrounded)
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
