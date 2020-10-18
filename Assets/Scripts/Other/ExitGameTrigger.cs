using UnityEngine;

namespace Shipov_FP_Adventure
{
    public class ExitGameTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject _exitGame;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.GetComponent<PlayerInventory>().IsHasCphere)
                {
                    _exitGame.SetActive(true);
                }
            }
        }
    }
}
