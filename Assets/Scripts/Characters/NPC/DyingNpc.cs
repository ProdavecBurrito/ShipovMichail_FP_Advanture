using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class DyingNpc : MonoBehaviour
    {
        #region Fields

        [SerializeField] private bool _isDying;
        [SerializeField] private Dialogue _dialogue;

        private CapsuleCollider _capsuleCollider;
        private Animator _animator;
        private Rigidbody _rigidbody;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            CheckThatNeedToDie();
        }

        #endregion


        #region Methods

        private void CheckThatNeedToDie()
        {
            if (_dialogue.IsAlreadySpoke)
            {
                if (!_isDying)
                {
                    Debug.Log("Die");
                    _animator.SetTrigger("Die");
                    _isDying = true;
                }
            }
        }

        private void Die()
        {
            _animator.enabled = false;
            _rigidbody.isKinematic = false;
            _capsuleCollider.enabled = false;
        }

        #endregion
    }
}
