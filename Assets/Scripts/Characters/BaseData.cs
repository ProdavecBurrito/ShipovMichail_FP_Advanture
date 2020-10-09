using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class BaseData : MonoBehaviour, IGetDamageable
    {
        public CharacterData CharacterData;

        public void GetDamage(int damage)
        {
            CharacterData.Health -= damage;
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
