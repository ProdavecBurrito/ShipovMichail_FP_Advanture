using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PlayerAnimation : MonoBehaviour
    {
        #region Fields
        
        private Animator _animator;
        private PlayerMovement _playerMovement;
        private InputManager _inputManager;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            CheckJumpAnimation();
            SetMovementAnimation();
            CheckThatStrafe();
        }
        #endregion


        #region Methods

        private void SetMovementAnimation()
        {
            if (_inputManager.CheckThatPressedRunButton())
            {
                _animator.SetBool("IsRun", true);
            }
            else
            {
                _animator.SetBool("IsRun", false);
            }

            _animator.SetFloat("Direction", _inputManager.Movement.x);
            _animator.SetFloat("Speed", _inputManager.Movement.z);
            if (_animator.GetFloat("Speed") != 0)
            {
                _animator.SetBool("IsWalk", true);
            }
            else
            {
                _animator.SetBool("IsWalk", false);
            }
        }

        private void CheckJumpAnimation()
        {
            if (_playerMovement.IsJump)
            {
                _animator.SetBool("IsJump", true);
            }
            else
            {
                _animator.SetBool("IsJump", false);
            }
        }

        private void CheckThatStrafe()
        {
            if (_playerMovement.IsStrafe)
            {
                _animator.SetBool("IsStrafe", true);
            }
            else
            {
                _animator.SetBool("IsStrafe", false);
            }
        }


        #endregion
    }
}
