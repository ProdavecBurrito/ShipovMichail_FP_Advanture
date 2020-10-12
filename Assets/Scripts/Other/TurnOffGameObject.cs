using UnityEngine;
using System.Collections.Generic;


namespace Shipov_FP_Adventure
{
    [RequireComponent(typeof(CheckRangeToTarget))]
    public class TurnOffGameObject : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _objs;
        [SerializeField] private float range = 60f;

        private Transform _player;
        private CheckRangeToTarget _checkRange;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _checkRange = GetComponent<CheckRangeToTarget>();
        }

        private void Update()
        {
            for (int i = 0; i < _objs.Count; i++)
            {
                if (_objs[i] == null)
                {
                    _objs.Remove(_objs[i]);
                }
                else
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
}
