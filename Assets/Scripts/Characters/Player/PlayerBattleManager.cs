using UnityEngine;
using UnityEngine.UI;


namespace Shipov_FP_Adventure
{
    public class PlayerBattleManager : MonoBehaviour
    {
        [SerializeField] private Sword _sword;
        [SerializeField] private Shield _shield;
        [SerializeField] private WeaponData _shieldData;
        [SerializeField] private WeaponData _swordData;
        private BaseData _playerData;
        private RestoreStamina _restoreStamina;

        private void Start()
        {
            _restoreStamina = GetComponent<RestoreStamina>();
            _playerData = GetComponent<BaseData>();
        }


        public void ShieldAttack()
        {
            _shield.ShieldAttack();
            _playerData.ReduceStamina(_shieldData.WasteOfStamina);
            _restoreStamina.StartRestoreTimer();
        }

        public void StopShieldAttack()
        {
            _shield.StopShieldAttack();
        }

        public void SwordAttack()
        {
            _sword.SwordAttack();
            _playerData.ReduceStamina(_swordData.WasteOfStamina);
            _restoreStamina.StartRestoreTimer();
        }

        public void StopSwordAttack()
        {
            _sword.StopSwordAttack();
        }
    }
}
