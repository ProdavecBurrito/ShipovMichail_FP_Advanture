using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


namespace Shipov_FP_Adventure
{
    public sealed class PostProcessingController : MonoBehaviour
    {
        private ChromaticAberration _chromaticAberration;
        [SerializeField] private PostProcessProfile processProfile;
        public PostProcessVolume kek;
        [SerializeField] private BaseData _playerData;

        private void Start()
        {
            _chromaticAberration = processProfile.GetSetting<ChromaticAberration>();
            _chromaticAberration.intensity.value = 0f;
            //_playerData = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseData>();
        }

        private void Update()
        {
            ChangeAberration();
        }

        private void ChangeAberration()
        {
            if (_playerData.IsStaminaChange)
            {
                _chromaticAberration.intensity.value = Mathf.Abs(_playerData.GetStamina() / 100 - 1);
            }
        }

    }
}
