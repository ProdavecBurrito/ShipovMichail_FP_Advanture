using UnityEngine;
using UnityEngine.UI;


namespace Shipov_FP_Adventure
{
    public class Dialogue : MonoBehaviour
    {
        public CharacterData _character;

        public Text CharacterNameText;
        public Text UICurrentSentence;
        public RectTransform TextPanel;
        public RectTransform UsePanel;

        private MouseLook _mouseLook;
        private PlayerMovement _playerMovement;
        private PlayerAnimation _playerAnimator;
        

        [SerializeField] private bool _isAlreadySpoke;
        [SerializeField] private bool _isTalking;

        public bool IsAlreadySpoke => _isAlreadySpoke;
        public bool IsTalking => _isTalking;


        [TextArea(3, 10)]
        public string[] _sentences;
        [TextArea(3, 10)]
        public string _alreadySpokeSentance;

        private string _currentSentence;
        private string _name;
        private int _currentSentenceNumber;

        private void Start()
        {
            _playerAnimator = FindObjectOfType<PlayerAnimation>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _mouseLook = FindObjectOfType<MouseLook>();
            _isAlreadySpoke = false;
            _name = _character.Name;
        }

        public void StartDialogue()
        {
            _mouseLook.UnlockCursor();
            _mouseLook.enabled = false;
            _playerAnimator.enabled = false;
            _playerMovement.enabled = false;
            UsePanel.gameObject.SetActive(false);
            _isTalking = true;
            _currentSentenceNumber = 0;
            CharacterNameText.text = _name;
            if (!TextPanel.gameObject.activeSelf)
            {
                TextPanel.gameObject.SetActive(true);
            }

            if (!_isAlreadySpoke)
            {
                _currentSentence = _sentences[0];
            }
            else
            {
                _currentSentence = _alreadySpokeSentance;
            }

            UICurrentSentence.text = _currentSentence;
        }

        public void NextSentence()
        {
            if (_isTalking)
            {
                if (!_isAlreadySpoke)
                {
                    _currentSentenceNumber += 1;
                    if (_currentSentenceNumber >= _sentences.Length)
                    {
                        _playerMovement.enabled = true;
                        _mouseLook.LockCursor();
                        _mouseLook.enabled = true;
                        _playerAnimator.enabled = true;
                        _isAlreadySpoke = true;
                        TextPanel.gameObject.SetActive(false);
                        _isTalking = false;
                    }
                    else
                    {
                        _currentSentence = _sentences[_currentSentenceNumber];
                        UICurrentSentence.text = _currentSentence;
                    }
                }
                else
                {
                    _playerMovement.enabled = true;
                    _playerAnimator.enabled = true;
                    _mouseLook.LockCursor();
                    _mouseLook.enabled = true;
                    _isTalking = false;
                    TextPanel.gameObject.SetActive(false);
                }
            }
        }
    }
}
