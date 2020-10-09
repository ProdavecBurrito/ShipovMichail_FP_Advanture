using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class GroundChecker : MonoBehaviour
    {
        #region Constants

        private const float CHECK_RADIUS = 0.2f;

        #endregion


        #region Fields

        [SerializeField] LayerMask _ground;
        [SerializeField] private bool _isGrounded;

        private Transform _groundCheker;

        #endregion


        #region Properties

        public bool IsGrounded => _isGrounded;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _groundCheker = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        #endregion


        #region Methods

        private void CheckGround()
        {
            _isGrounded = Physics.CheckSphere(_groundCheker.position, CHECK_RADIUS, _ground);
        }

        #endregion
    }
}
