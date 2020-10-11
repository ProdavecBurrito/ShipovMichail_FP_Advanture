using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class StartMenu : MonoBehaviour
    {
        private InputManager _inputManager;
        private Pause _pause;

        private void Start()
        {
            _pause = GetComponent<Pause>();
            gameObject.SetActive(true);
            _inputManager = GetComponent<InputManager>();
            _pause.PauseOn();
        }

        private void Update()
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            if (_inputManager.PressedMenu())
            {
                _pause.PauseOff();
                Destroy(gameObject);
            }
        }
    }
}
