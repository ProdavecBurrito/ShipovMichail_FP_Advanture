using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private GameObject _weapon;

        public void ShieldAttack()
        {
            _weapon.SetActive(true);
        }

        public void StopShieldAttack()
        {
            _weapon.SetActive(false);
        }
    }
}
