using UnityEngine;
using System.Collections.Generic;


namespace Shipov_FP_Adventure
{
    public sealed class MainController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private BaseData _player;
        private List<IUpdatable> _ibdatables = new List<IUpdatable>();

        #endregion


        #region UnityMethods

        private void Update()
        {
            for (int i = 0; i < _ibdatables.Count; i++)
            {
                _ibdatables[i].UpdateTick();
            }
        }

        #endregion


        #region Methods

        public void AddUpdatable(IUpdatable updatable)
        {
            _ibdatables.Add(updatable);
        }

        #endregion
    }
}
