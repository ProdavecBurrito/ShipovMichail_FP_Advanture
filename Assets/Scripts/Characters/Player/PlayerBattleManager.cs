using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class PlayerBattleManager : MonoBehaviour
    {
        [SerializeField] private Sword _sword;
        [SerializeField] private Shield _shield;

        public void ShieldAttack()
        {
            _shield.ShieldAttack();
        }

        public void StopShieldAttack()
        {
            _shield.StopShieldAttack();
        }

        public void SwordAttack()
        {
            _sword.SwordAttack();
        }

        public void StopSwordAttack()
        {
            _sword.StopSwordAttack();
        }
    }
}
