using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class InputManager : MonoBehaviour
    {
        #region Fields

        public KeyCode Heal = KeyCode.T;
        public KeyCode Jump = KeyCode.Space;
        public KeyCode Run = KeyCode.LeftShift;
        public KeyCode Use = KeyCode.E;
        public KeyCode Attack = KeyCode.Mouse0;
        public KeyCode Block = KeyCode.Mouse1;
        public KeyCode DrawWeapon = KeyCode.F;
        public KeyCode Menu = KeyCode.Escape;
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

        public bool PressedAttack()
        {
            return Input.GetKeyDown(Attack);
        }

        public bool PressedMenu()
        {
            return Input.GetKeyDown(Menu);
        }

        public bool PressedDrawWeapon()
        {
            return Input.GetKeyDown(DrawWeapon);
        }

        public bool PressedThatJump()
        {
            return Input.GetKeyDown(Jump);
        }

        public bool PressedRunButton()
        {
            return Input.GetKey(Run);
        }

        public bool PressedUse()
        {
            return Input.GetKeyDown(Use);
        }

        public bool PressedBlock()
        {
            return Input.GetKey(Block);
        }

        public bool PressedHeal()
        {
            return Input.GetKeyDown(Heal);
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
