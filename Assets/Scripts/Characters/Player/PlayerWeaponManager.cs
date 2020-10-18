using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class PlayerWeaponManager : MonoBehaviour
    {
        [SerializeField] private GameObject _sword;
        [SerializeField] private GameObject _swordInHand;

        [SerializeField] private bool _isArmed;

        public bool IsArmed => _isArmed;

        private void Start()
        {
            _isArmed = false;
        }

        public void DrawSword()
        {
            if (_isArmed == false)
            {
                _sword.SetActive(false);
                _swordInHand.SetActive(true);
                _isArmed = true;
            }
            else if (_isArmed == true)
            {
                _sword.SetActive(true);
                _swordInHand.SetActive(false);
                _isArmed = false;
            }
        }
    }
}
