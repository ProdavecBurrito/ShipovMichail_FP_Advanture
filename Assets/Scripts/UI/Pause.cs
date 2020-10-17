using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class Pause : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject[] _menus;
        private PlayerAnimation _playerAnimation;
        private PlayerMovement _playerMovement;
        private MouseLook _mouseLook;
        private bool _isPaused;

        #endregion


        #region UnityMethods


        private void Start()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _playerAnimation = FindObjectOfType<PlayerAnimation>();
            _mouseLook = FindObjectOfType<MouseLook>();
        }

        private void Update()
        {
            CheckMenuActivity();
        }

        private void CheckMenuActivity()
        {
            for (int i = 0; i < _menus.Length; i++)
            {
                if (_menus[i].activeSelf)
                {
                    if (!_isPaused)
                    {
                        _isPaused = true;
                        PauseOn();
                    }
                    break;
                }
                else if (i == _menus.Length -1 && _isPaused)
                {
                    _isPaused = false;
                    PauseOff();
                }
            }
        }

        public void PauseOn()
        {
            Cursor.visible = true;
            Debug.Log("Kek");
            LockScripts();
            Time.timeScale = 0;
        }

        public void PauseOff()
        {
            Cursor.visible = false;
            Debug.Log("Дуд");
            UnlockScripts();
            Time.timeScale = 1;
        }

        public void LockScripts()
        {
            _mouseLook.UnlockCursor();
            _playerAnimation.enabled = false;
            _playerMovement.enabled = false;
        }

        public void UnlockScripts()
        {
            _mouseLook.LockCursor();
            _playerAnimation.enabled = true;
            _playerMovement.enabled = true;
        }

        #endregion
    }
}
