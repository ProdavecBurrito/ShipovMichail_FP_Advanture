using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class BaseData : MonoBehaviour, IGetDamageable
    {
        public CharacterData CharacterData;

        private void Start()
        {
            CharacterData.Health = CharacterData.MaxHealth;
        }

        public void GetDamage(int damage)
        {
            CharacterData.Health -= damage;

            if (CharacterData.Health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void RestoreHealth()
        {
            CharacterData.Health = CharacterData.MaxHealth;
        }

        public void ReduceStamina(int number)
        {
            CharacterData.Stamina -= number;
        }

        public void RestoreStamina()
        {
            CharacterData.Stamina = CharacterData.MaxStamina;
        }
    }
}
