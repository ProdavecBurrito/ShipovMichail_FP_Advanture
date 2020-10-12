using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class BaseData : MonoBehaviour, IGetDamageable
    {
        public CharacterData CharacterData;
        public ChangeUIValue HealthValue;
        public ChangeUIValue StaminaValue;

        private void Start()
        {
            CharacterData.Health = CharacterData.MaxHealth;
            CharacterData.Stamina = CharacterData.MaxStamina;
        }

        public void GetDamage(int damage)
        {
            CharacterData.Health -= damage;
            HealthValue.ChangeValueUI(damage);

            if (CharacterData.Health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void RestoreMaxHealth()
        {
            CharacterData.Health = CharacterData.MaxHealth;
        }

        public void RestoreMaxStamina()
        {
            CharacterData.Stamina = CharacterData.MaxStamina;
        }

        public void ReduceStamina(int number)
        {
            CharacterData.Stamina -= number;
            StaminaValue.ChangeValueUI(number);
        }

        public void RestoreStamina()
        {
            CharacterData.Stamina += 1;
            StaminaValue.ChangeValueUI(-1);
        }

        public bool IsMaxStamina()
        {
            return CharacterData.Stamina >= CharacterData.MaxStamina;
        }
    }
}
