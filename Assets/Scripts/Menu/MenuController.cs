using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _menus;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private GameObject _pauseMenu;
        private bool _isMenuActive;

        private void Start()
        {
            _inputManager = FindObjectOfType<InputManager>();
        }

        private void Update()
        {
            CheckMenus();
        }

        private void CheckMenus()
        {
            if (_inputManager.PressedMenu())
            {
                _isMenuActive = false;
                for (int i = 0; i < _menus.Length; i++)
                {
                    if (_menus[i].activeSelf)
                    {
                        _menus[i].SetActive(false);
                        _isMenuActive = true;
                        break;
                    }
                }
                if (!_isMenuActive)
                {
                    _pauseMenu.SetActive(true);
                }
            }
        }
    }
}
