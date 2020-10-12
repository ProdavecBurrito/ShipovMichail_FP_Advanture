using UnityEngine;
using UnityEngine.UI;


namespace Shipov_FP_Adventure
{
    public class ChangeUIValue : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void ChangeValueUI(float value)
        {
            _image.fillAmount = _image.fillAmount - (value / 100);
            Debug.Log(_image.fillAmount);
        }
    }
}

