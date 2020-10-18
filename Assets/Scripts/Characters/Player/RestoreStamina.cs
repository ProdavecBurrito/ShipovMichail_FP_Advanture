using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class RestoreStamina : MonoBehaviour
    {
        [SerializeField] private float _restoreTime;
        [SerializeField] private float _currentRestoreTime;
        private BaseData _baseData;
        public bool IsRestore;

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
            IsRestore = true;
        }

        private void StartRestoreStamina()
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
                    IsRestore = false;
                }
            }
        }
    }
}
