using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PeacefulTalkingNpc : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float _distanceToPlayer;
        [SerializeField] private float _headFolowDistance;
        [SerializeField] private Transform _playerHead;
        [SerializeField] public bool _isAggressive;

        private CheckRangeToTarget _checkRange;
        private Dialogue _dialogue;
        private Animator _animator;
        private Transform _player;
        

        #endregion


        #region UnityMethods

        private void Start()
        {
            _dialogue = GetComponent<Dialogue>();
            _checkRange = GetComponent<CheckRangeToTarget>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            CheckThatNeedCallTarget();
        }

        private void OnAnimatorIK()
        {
            CheckHeadFollow();
        }

        #endregion


        #region Methods

        private void CheckHeadFollow()
        {
            if (_checkRange.CheckinMinDistanceToObject(_player, _headFolowDistance))
            {
                _animator.SetLookAtWeight(1);
                _animator.SetLookAtPosition(_playerHead.position);
            }
        }

        private void CheckThatNeedCallTarget()
        {
            if (!_isAggressive)
            {
                if (!_dialogue.IsTalking && !_dialogue.IsAlreadySpoke)
                {
                    if (_checkRange.CheckinMinDistanceToObject(_player, _distanceToPlayer))
                    {
                        _animator.SetBool("IsSeeTarget", true);
                    }
                    else
                    {
                        _animator.SetBool("IsSeeTarget", false);
                    }
                }
                else
                {
                    _animator.SetBool("IsSeeTarget", false);
                }
            }
        }

        #endregion
    }
}
