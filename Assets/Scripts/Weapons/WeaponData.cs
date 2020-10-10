using UnityEngine;

namespace Shipov_FP_Adventure
{
    [CreateAssetMenu(fileName = "WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public int Damage;
        public int WasteOfStamina;
    }
}
