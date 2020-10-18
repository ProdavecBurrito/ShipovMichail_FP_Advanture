using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class Takable : MonoBehaviour
    {
        private PlayerInventory _playerInventory;

        private void Start()
        {
            _playerInventory = FindObjectOfType<PlayerInventory>();
            
        }

        public void Take()
        {
            Destroy(gameObject);
            _playerInventory.IsHasCphere = true;
        }
    }
}
