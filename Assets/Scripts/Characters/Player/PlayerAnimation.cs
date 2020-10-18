using System;
using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PlayerAnimation : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Sword _sword;

        private Animator _animator;
        private PlayerMovement _playerMovement;
        private InputManager _inputManager;
        private PlayerWeaponManager _playerManager;
        private BaseData _characterData;
        private bool _isAttack;
        private bool _isSecondAttack;
        private bool _isThirdAttack;

        public bool IsAttack => _isAttack;
        public bool IsSecondAttack => _isSecondAttack;
        public bool IsThirdAttack => _isThirdAttack;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _characterData = GetComponent<BaseData>();
            _playerManager = GetComponent<PlayerWeaponManager>();
            _isAttack = false;
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            CheckThatAttack();
            CheckJumpAnimation();
            SetMovementAnimation();
            CheckThatStrafe();
            CheckThatDrawWeapon();
            CheckThatHeal();
        }

        #endregion


        #region Methods

        private void SetMovementAnimation()
        {
            if (_inputManager.PressedRunButton() && _playerMovement.IsRun == true)
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
            _isThirdAttack = false;
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

        private void CheckThatHeal()
        {
            if (_inputManager.PressedHeal())
            {
                _animator.SetBool("Heal", true);
                _characterData.HealingCphere.SetActive(true);
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
                _sword.PlayOffDrawSound();
            }
            else if (_inputManager.PressedDrawWeapon() && !_playerManager.IsArmed)
            {
                _animator.SetTrigger("DrawWeapon");
                _sword.PlayDrawSound();
            }
        }

        public void EndAttack()
        {
            _animator.SetBool("Attack", false);
        }

        public void EndSecondAttack()
        {
            _animator.SetBool("SecondAttack", false);
        }

        public void EndThirdAttack()
        {
            _animator.SetBool("ThirdAttack", false);
        }

        private void CancelAnim()
        {
            _animator.SetBool("Attack", false);
            _animator.SetBool("SecondAttack", false);
            _animator.SetBool("ThirdAttack", false);
        }

        private void CheckThatAttack()
        {
            if (_playerManager.IsArmed && _inputManager.PressedAttack() && _characterData.GetStamina() > 0)
            {
                if (!_animator.GetBool("Attack") && !_animator.GetBool("SecondAttack") && !_animator.GetBool("ThirdAttack"))
                {
                    _animator.SetBool("Attack", true);
                }
                else if (_animator.GetBool("Attack") && !_animator.GetBool("SecondAttack") && !_animator.GetBool("ThirdAttack"))
                {
                    _animator.SetBool("SecondAttack", true);
                }
                else if (!_animator.GetBool("Attack") && _animator.GetBool("SecondAttack") && !_animator.GetBool("ThirdAttack"))
                {
                    _animator.SetBool("ThirdAttack", true);
                }
                else if (!_animator.GetBool("Attack") && !_animator.GetBool("SecondAttack") && _animator.GetBool("ThirdAttack"))
                {
                    _animator.SetBool("Attack", true);
                }
                else if (_animator.GetBool("SecondAttack") && _animator.GetBool("ThirdAttack") && _animator.GetBool("Attack"))
                {
                    CancelAnim();
                }

            }
        }

        private void СancelHeal()
        {
            _animator.SetBool("Heal", false);
        }


        #endregion
    }
}
