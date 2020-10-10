using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimator;
        [SerializeField] private WeaponData _weaponData;
        [SerializeField] private GameObject _weapon;
        [SerializeField] private LayerMask _enemies;
        private RaycastHit _hit;
        private bool _isHit;

        private void Update()
        {
            if (_playerAnimator.IsAttack || _playerAnimator.IsThirdAttack)
            {
                SwordAttack();
            }
            else
            {
                _isHit = false;
                _weapon.SetActive(false);
            }
        }



        public void SwordAttack()
        {
            Debug.DrawLine(_weapon.transform.position, _weapon.transform.forward);
            _weapon.SetActive(true);
            if (!_isHit)
            {
                if (Physics.Raycast(_weapon.transform.position, _weapon.transform.forward, out _hit, 11f, _enemies))
                {
                    Debug.Log("Kek");
                    _hit.collider.gameObject.GetComponent<IGetDamageable>().GetDamage(_weaponData.Damage);
                    _isHit = true;
                }
            }
        }
    }
}
