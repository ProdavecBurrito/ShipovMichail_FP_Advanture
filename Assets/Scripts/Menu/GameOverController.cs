using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class GameOverController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _exitPanel;
        private InputManager _inputManager;
        private BaseData _player;
        private PlayerAnimation _playerAnimation;
        private PlayerMovement _playerMovement;
        private MouseLook _mouseLook;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _inputManager = FindObjectOfType<InputManager>();
            _player = FindObjectOfType<BaseData>();
            _playerAnimation = FindObjectOfType<PlayerAnimation>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _mouseLook = FindObjectOfType<MouseLook>();
        }

        private void FixedUpdate()
        {
            CheckThatGameOverProcessIsOn();
        }

        #endregion


        #region Methods

        private void CheckThatGameOverProcessIsOn()
        {
            if (_player.GetHealth() < 1)
            {
                _playerAnimation.enabled = false;
                _playerMovement.enabled = false;
                _mouseLook.enabled = false;
                _player.enabled = false;
                _inputManager.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                _exitPanel.SetActive(true);
            }
        }

        #endregion
    }
}
