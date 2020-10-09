using UnityEngine;
using UnityEngine.UI;


namespace Shipov_FP_Adventure
{
    public class Dialogue : MonoBehaviour
    {
        public CharacterData _character;

        public Text NameText;
        public Text CurrentSentence;
        public RectTransform TextPanel;
        public RectTransform UsePanel;

        private MouseLook _mouseLook;
        private PlayerMovement _playerMovement;
        

        private bool _isAlreadySpoke;
        private bool _isTalking;

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
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _mouseLook = FindObjectOfType<MouseLook>();
            _isAlreadySpoke = false;
            _name = _character.Name;
        }

        public void StartDialogue()
        {
            _mouseLook.UnlockCursor();
            _mouseLook.enabled = false;
            _playerMovement.enabled = false;
            UsePanel.gameObject.SetActive(false);
            _isTalking = true;
            _currentSentenceNumber = 0;
            NameText.text = _name;
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

            CurrentSentence.text = _currentSentence;
        }

        public void NextSentence()
        {
            if (!_isAlreadySpoke)
            {
                _currentSentenceNumber += 1;
                if (_currentSentenceNumber >= _sentences.Length)
                {
                    _playerMovement.enabled = true;
                    _mouseLook.LockCursor();
                    _mouseLook.enabled = true;
                    _isAlreadySpoke = true;
                    TextPanel.gameObject.SetActive(false);
                }
                else
                {
                    _currentSentence = _sentences[_currentSentenceNumber];
                    CurrentSentence.text = _currentSentence;
                }
            }
            else
            {
                _playerMovement.enabled = true;
                _mouseLook.LockCursor();
                _mouseLook.enabled = true;
                _isTalking = false;
                TextPanel.gameObject.SetActive(false);
            }
        }
    }
}
