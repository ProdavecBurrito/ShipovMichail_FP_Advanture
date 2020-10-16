using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class BaseData : MonoBehaviour, IGetDamageable
    {
        public CharacterData CharacterData;
        public ChangeUIValue HealthValue;
        public ChangeUIValue StaminaValue;
        public MusicChanger _musicChanger;
        public float _musicCalmTime;
        public float _currentMusicCalmTime;
        public bool IsStaminaChange;
        public bool IsBattle;
        public GameObject HealingCphere;

        private void Start()
        {
            HealingCphere.SetActive(false);
            Cursor.visible = false;
            CharacterData.Health = CharacterData.MaxHealth;
            CharacterData.Stamina = CharacterData.MaxStamina;
        }

        private void Update()
        {
            CountNotWoundedTime();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Village"))
            {
                _musicChanger.VillageMusic();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Village"))
            {
                _musicChanger.CalmMusic();
            }
        }

        public void GetDamage(int damage)
        {
            CharacterData.Health -= damage;
            HealthValue.ChangeValueUI(damage);
            Battle();

            if (CharacterData.Health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void RestoreMaxHealth()
        {
            CharacterData.Health = CharacterData.MaxHealth;
            HealthValue.ChangeValueUI();
            HealingCphere.SetActive(false);
        }

        public void RestoreMaxStamina()
        {
            CharacterData.Stamina = CharacterData.MaxStamina;
            IsStaminaChange = false;
        }

        public void ReduceStamina(float number)
        {
            CharacterData.Stamina -= number;
            StaminaValue.ChangeValueUI(number);
            IsStaminaChange = true;
        }

        public void RestoreStamina()
        {
            CharacterData.Stamina += 2;
            StaminaValue.ChangeValueUI(-2);
        }

        public bool IsMaxStamina()
        {
            return CharacterData.Stamina >= CharacterData.MaxStamina;
        }

        public float GetStamina()
        {
            return CharacterData.Stamina;
        }

        public float GetHealth()
        {
            return CharacterData.Health;
        }

        private void Battle()
        {
            if (!IsBattle)
            {
                _musicChanger.BattleMusic();
                IsBattle = true;
            }
            else
            {
                _currentMusicCalmTime = 0;
            }
        }

        private void CountNotWoundedTime()
        {
            if (IsBattle)
            {
                if (_currentMusicCalmTime < _musicCalmTime)
                {
                    _currentMusicCalmTime += Time.deltaTime;
                }
                else
                {
                    _currentMusicCalmTime = 0.0f;
                    _musicChanger.CalmMusic();
                    IsBattle = false;
                }
            }
        }
    }
}
