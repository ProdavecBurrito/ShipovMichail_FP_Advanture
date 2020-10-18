using UnityEngine;
using UnityEngine.UI;


namespace Shipov_FP_Adventure
{
    public class ChangeUIValue : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private BaseEnemy _baseEnemy;
        private bool _isBot;

        private void Start()
        {
            if (gameObject.layer.Equals("Enemy") || gameObject.CompareTag("Enemy"))
            {
                _isBot = true;
                _baseEnemy = GetComponent<BaseEnemy>();
            }
        }

        public void ChangeValueUI(float value)
        {
            if (_isBot)
            {
                _image.fillAmount = _image.fillAmount - (value / _baseEnemy.MaxHealth);
            }
            else
            {
                _image.fillAmount = _image.fillAmount - (value / 100);
            }
        }

        public void ChangeValueUI()
        {
            _image.fillAmount = 1f;
        }
    }
}

