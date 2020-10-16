using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class StartMenu : MonoBehaviour
    {
        private InputManager _inputManager;

        private void Start()
        {
            _inputManager = FindObjectOfType<InputManager>();
            gameObject.SetActive(true);
        }
    }
}
