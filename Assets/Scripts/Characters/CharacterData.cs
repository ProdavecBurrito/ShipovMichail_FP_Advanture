using UnityEngine;

namespace Shipov_FP_Adventure
{
    [CreateAssetMenu(fileName = "CharacterData")]
    public sealed class CharacterData : ScriptableObject
    {
        public string Name;
        public float Stamina;
        public float Health;
        public float MaxHealth;
        public float MaxStamina;
    }
}
