using UnityEngine;

namespace Shipov_FP_Adventure
{
    [CreateAssetMenu(fileName = "CharacterData")]
    public sealed class CharacterData : ScriptableObject
    {
        public string Name;
        public int Stamina;
        public int Health;
        public int MaxHealth;
        public int MaxStamina;
    }
}
