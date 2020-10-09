using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class InputManager : MonoBehaviour
    {
        #region Fields

        public KeyCode Jump = KeyCode.Space;
        public KeyCode Run = KeyCode.LeftShift;
        public KeyCode Use = KeyCode.E;
        public KeyCode Attack = KeyCode.Mouse0;
        public KeyCode DrawWeapon = KeyCode.F;
        public Vector3 Movement;
        public float RotationX;
        public float RotationY;

        #endregion


        #region UnityMethods

        private void Update()
        {
            MoveChar();
            RotateChar();
        }

        #endregion


        #region Methods

        public bool CheckThatAttack()
        {
            return Input.GetKeyDown(Attack);
        }

        public bool CheckThatDrawWeapon()
        {
            return Input.GetKeyDown(DrawWeapon);
        }

        public bool CheckThatJump()
        {
            return Input.GetKeyDown(Jump);
        }

        public bool CheckThatPressedRunButton()
        {
            return Input.GetKey(Run);
        }

        public bool CheckThatUse()
        {
            return Input.GetKeyDown(Use);
        }

        private void MoveChar()
        {
            Movement.x = Input.GetAxis("Horizontal");
            Movement.z = Input.GetAxis("Vertical");
        }

        private void RotateChar()
        {
            RotationX = Input.GetAxis("Mouse X");
            RotationY = Input.GetAxis("Mouse Y");
        }

        #endregion
    }
}
