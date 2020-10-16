using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class EnemyData : MonoBehaviour
    {
        public CharacterData CharacterData;
        public ChangeUIValue HealthValue;

        private void Start()
        {
            HealthValue = GetComponentInChildren<ChangeUIValue>();
            CharacterData.Health = CharacterData.MaxHealth;
        }

        public void RestoreMaxHealth()
        {
            CharacterData.Health = CharacterData.MaxHealth;
        }
    }
}
