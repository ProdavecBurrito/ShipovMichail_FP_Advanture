using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class RestoreStamina : MonoBehaviour
    {
        [SerializeField] private float _restoreTime;
        [SerializeField] private float _currentRestoreTime;
        [SerializeField] private bool _isNeedToRestore;
        private BaseData _baseData;

        private void Start()
        {
            _baseData = GetComponent<BaseData>();
            _currentRestoreTime = 0;
        }

        private void Update()
        {
            StartRestoreStamina();
        }

        public void StartRestoreTimer()
        {
            _currentRestoreTime = 0;
        }

        public void StartRestoreStamina()
        {
            if (_currentRestoreTime < _restoreTime)
            {
                _currentRestoreTime += Time.deltaTime;
            }
            else
            {
                if (!_baseData.IsMaxStamina())
                {
                    _baseData.RestoreStamina();
                }
                else
                {
                    _baseData.RestoreMaxStamina();
                }
            }
        }
    }
}
