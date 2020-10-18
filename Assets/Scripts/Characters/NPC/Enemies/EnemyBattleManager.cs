using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class EnemyBattleManager : MonoBehaviour
    {
        [SerializeField] private Sword _sword;

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
