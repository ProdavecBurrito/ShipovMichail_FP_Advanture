using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class MouseLook : MonoBehaviour
    {
        #region Constants

        private const float ZERO_ROTATION = 0f;

        #endregion


        #region Fields

        [SerializeField] private float _sensitivity;
        [SerializeField] private float _maxRotationAngle;
        [SerializeField] Transform _player;

        private InputManager _inputManager;
        private float _mouseRotationX;
        private float _mouseRotationY;
        private float _yAxisRotation;

        #endregion


        #region UnityMethods

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _inputManager = GetComponentInParent<InputManager>();
        }

        private void FixedUpdate()
        {
            RotatePlayer();
        }

        #endregion


        #region Methods

        private void RotatePlayer()
        {
            _mouseRotationX = _inputManager.RotationX * _sensitivity * Time.deltaTime;
            _mouseRotationY = _inputManager.RotationY * _sensitivity * Time.deltaTime;

            _yAxisRotation -= _mouseRotationY;
            _yAxisRotation = Mathf.Clamp(_yAxisRotation, -_maxRotationAngle, _maxRotationAngle);

            transform.localRotation = Quaternion.Euler(_yAxisRotation, ZERO_ROTATION, ZERO_ROTATION);
            _player.Rotate(Vector3.up * _mouseRotationX);

        }

        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        #endregion
    }
}
