using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class PlayerUse : MonoBehaviour
    {
        private StartDialogue _startDialogue;
        private InputManager _inputManager;
        private Dialogue _dialogue;

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
            _startDialogue = GetComponent<StartDialogue>();
        }

        private void Update()
        {
            if (_inputManager.CheckThatUse() && _startDialogue.IsUsePanelActive)
            {
                _dialogue.StartDialogue();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Usable"))
            {
                _dialogue = other.GetComponent<Dialogue>();
                _startDialogue.ShowUseButton();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _startDialogue.HideUseButton();
        }
    }
}
