using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class Pause : MonoBehaviour
    {
        #region Fields

        private MouseLook _mouseLook;
        private PlayerMovement _playerMovement;
        private PlayerAnimation _playerAnimator;

        #endregion


        #region UnityMethods


        private void Start()
        {
            _playerAnimator = FindObjectOfType<PlayerAnimation>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _mouseLook = FindObjectOfType<MouseLook>();
        }

        public void PauseOn()
        {
            _playerAnimator.enabled = false;
            _playerMovement.enabled = false;
            _mouseLook.enabled = false;

            Time.timeScale = 0;
        }

        public void PauseOff()
        {
            _playerAnimator.enabled = true;
            _playerMovement.enabled = true;
            _mouseLook.enabled = true;
            Time.timeScale = 1;
        }

        #endregion
    }
}
