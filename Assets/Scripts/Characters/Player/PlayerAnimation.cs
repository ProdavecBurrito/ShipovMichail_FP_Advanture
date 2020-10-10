using System;
using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PlayerAnimation : MonoBehaviour
    {
        #region Fields

        private Animator _animator;
        private PlayerMovement _playerMovement;
        private InputManager _inputManager;
        private PlayerWeaponManager _playerManager;
        private bool _isAttack;
        private bool _isSecondAttack;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _playerManager = GetComponent<PlayerWeaponManager>();
            _isAttack = false;
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            CheckJumpAnimation();
            SetMovementAnimation();
            CheckThatStrafe();
            CheckThatDrawWeapon();
            CheckThatAttack();
        }

        #endregion


        #region Methods

        private void SetMovementAnimation()
        {
            if (_inputManager.PressedRunButton())
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

        private void CheckThatDrawWeapon()
        {
            if (_inputManager.PressedDrawWeapon() && _playerManager.IsArmed)
            {
                _animator.SetTrigger("DrawOffWeapon");
            }
            else if (_inputManager.PressedDrawWeapon() && !_playerManager.IsArmed)
            {
                _animator.SetTrigger("DrawWeapon");
            }
        }

        private void CheckThatAttack()
        {
            if (_playerManager.IsArmed)
            {
                if (_inputManager.PressedAttack() && !_isAttack && !_isSecondAttack)
                {
                    _animator.SetTrigger("Attack");
                    _isAttack = true;
                }
                else if (_inputManager.PressedAttack() && _isAttack && !_isSecondAttack)
                {
                    _animator.SetTrigger("SecondAttack");
                    _isAttack = false;
                    _isSecondAttack = true;
                }
                else if (_inputManager.PressedAttack() && !_isAttack && _isSecondAttack)
                {
                    _animator.SetTrigger("ThirdAttack");
                    _isSecondAttack = false;
                }
            }
        }


        #endregion
    }
}
