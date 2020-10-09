using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class HandObjDetection : MonoBehaviour
    {
        #region Constants

        private const float DETECTION_RANGE = 2.0f;

        #endregion


        #region Fields

        public bool _isLeftHandIKOn;
        public bool _isRightHandIKOn;

        [SerializeField] private Transform _leftHandObj;
        [SerializeField] private Transform _rightHandObj;
        [SerializeField] private LayerMask _wallLayer;
        [SerializeField] private Transform _leftHandStart;
        [SerializeField] private Transform _rightHandStart;

        private Animator _animator;
        private RaycastHit hit;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            CheckRange(_leftHandStart, ref _isLeftHandIKOn);

            CheckRange(_rightHandStart, ref _isRightHandIKOn);
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (_isLeftHandIKOn || _isRightHandIKOn)
            {
                if (_rightHandObj != null && _isRightHandIKOn)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandObj.rotation);
                }

                if (_rightHandObj != null && _isLeftHandIKOn)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandObj.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandObj.rotation);
                }
            }
        }

        #endregion


        #region Methods

        private bool CheckRange(Transform hand, ref bool isIKHandOn)
        {
            if (Physics.Raycast(hand.position, hand.forward, out hit, DETECTION_RANGE, _wallLayer))
            {
                return isIKHandOn = true;
            }
            else
            {
                return isIKHandOn = false;
            }
        }

        #endregion
    }
}
