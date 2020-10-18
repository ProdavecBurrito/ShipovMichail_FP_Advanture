using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class PlayerUse : MonoBehaviour
    {
        [SerializeField] Camera _mainCam;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Takable _thing;

        private StartDialogue _startDialogue;
        private InputManager _inputManager;
        private Dialogue _dialogue;
        private RaycastHit _hit;

        private void Start()
        {
            _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            _inputManager = GetComponent<InputManager>();
            _startDialogue = GetComponent<StartDialogue>();
        }

        private void Update()
        {
            FindUsableTargets();
        }

        private void FindUsableTargets()
        {
            if (Physics.Raycast(_mainCam.transform.position, _mainCam.transform.forward, out _hit, 2.5f, _layerMask))
            {
                if (!_hit.collider.gameObject.CompareTag("Usable"))
                {
                    if (_dialogue == null)
                    {
                        _dialogue = _hit.collider.gameObject.GetComponent<Dialogue>();
                    }

                    if (_dialogue != null && !_startDialogue.IsUsePanelActive && !_dialogue.IsTalking)
                    {
                        _startDialogue.ShowUseButton();
                    }

                    if (_dialogue != null &&_inputManager.PressedUse() && !_dialogue.IsTalking)
                    {

                        _dialogue.StartDialogue();
                    }

                    if (_dialogue != null && _dialogue.IsTalking)
                    {
                        _startDialogue.HideUseButton();
                    }
                }
                else if (_hit.collider.gameObject.CompareTag("Usable"))
                {
                    _startDialogue.ShowUseButton();
                    if (_inputManager.PressedUse() && _thing != null)
                    {
                        _thing.Take();
                        _startDialogue.HideUseButton();
                    }
                }
            }
            else
            {
                if (_startDialogue.IsUsePanelActive)
                {
                    _startDialogue.HideUseButton();
                }
                if (_dialogue != null)
                {
                    _dialogue = null;
                }
            }

        }
    }
}
