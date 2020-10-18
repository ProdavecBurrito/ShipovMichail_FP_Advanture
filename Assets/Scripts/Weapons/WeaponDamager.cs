using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class WeaponDamager : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;
        [SerializeField] bool _isHit;
        [SerializeField] private ParticleSystem _blood;

        private void Start()
        {
            _isHit = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isHit)
            {
                if (other.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<IGetDamageable>().GetDamage(_weaponData.Damage);
                    _blood.Play();
                    _isHit = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _isHit = false;
        }
    }
}
