using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class StartDialogue : MonoBehaviour
    {
        [SerializeField] private RectTransform UsePanel;

        [SerializeField] private bool _isUsePanelActive;

        public bool IsUsePanelActive => _isUsePanelActive;

        private void Start()
        {
            UsePanel.gameObject.SetActive(false);
        }

        public void ShowUseButton()
        {
            UsePanel.gameObject.SetActive(true);
            _isUsePanelActive = true;
        }

        public void HideUseButton()
        {
            UsePanel.gameObject.SetActive(false);
            _isUsePanelActive = false;
        }
    }
}
