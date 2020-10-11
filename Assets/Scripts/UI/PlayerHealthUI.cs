using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private CharacterData _charHealth;

        [SerializeField] private float _stepWight;
        [SerializeField] private float _stepHight;
        [SerializeField] private int _rectWigth;
        [SerializeField] private int _rectHight;
        [SerializeField] private int _textSize;

        private GUIStyle _style = new GUIStyle();

        private void Start()
        {
            _style.fontSize = _textSize;
            _style.normal.textColor = Color.green;
        }

        private void OnGUI()
        {
            GUI.Box(new Rect(Screen.width - Screen.width + _stepWight, Screen.height - _stepHight, _rectWigth, _rectHight), _charHealth.Health.ToString(), _style);
        }
    }
}
