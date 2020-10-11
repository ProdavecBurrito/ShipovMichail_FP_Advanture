using UnityEngine;


namespace Shipov_FP_Adventure
{
    [RequireComponent(typeof(CheckRangeToTarget))]
    public class TurnOffGameObject : MonoBehaviour
    {
        [SerializeField] private GameObject[] _objs;
        private Transform _player;

        private float range = 60f;
        private CheckRangeToTarget _checkRange;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _checkRange = GetComponent<CheckRangeToTarget>();
        }

        private void Update()
        {
            for (int i = 0; i < _objs.Length; i++)
            {
                if (((_player.position - _objs[i].transform.position).sqrMagnitude > range * range))
                {
                    _objs[i].SetActive(false);
                }
                else
                {
                    _objs[i].SetActive(true);
                }
            }
        }
    }
}
