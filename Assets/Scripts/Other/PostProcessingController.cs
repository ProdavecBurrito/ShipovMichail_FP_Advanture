using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


namespace Shipov_FP_Adventure
{
    public sealed class PostProcessingController : MonoBehaviour
    {
        [SerializeField] private PostProcessProfile _processProfile;
        [SerializeField] private BaseData _playerData;
        [SerializeField] private LayerMask _layerMask;
        private Color _redColor = Color.red;
        private Color _blackColor = Color.black;

        private Vignette _vignette;
        private Camera _mainCamera;
        private ChromaticAberration _chromaticAberration;
        private DepthOfField _depthOfField;

        private RaycastHit _hit;

        private float _maxFocusDistanse = 10.0f;
        private float _maxHeartVignette = 0.4f;

        private void Start()
        {
            _mainCamera = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();

            _vignette = _processProfile.GetSetting<Vignette>();
            _chromaticAberration = _processProfile.GetSetting<ChromaticAberration>();
            _depthOfField = _processProfile.GetSetting<DepthOfField>();

            _vignette.intensity.value = 0f;
            _depthOfField.focusDistance.value = _maxFocusDistanse;
            _chromaticAberration.intensity.value = 0f;
        }

        private void Update()
        {
            ChangeAberrationValue();
            ChangeDepthOfField();
            ChangeVignette();
        }

        private void ChangeAberrationValue()
        {
            if (_playerData.IsStaminaChange)
            {
                _chromaticAberration.intensity.value = Mathf.Abs(_playerData.GetStamina() / 100 - 1);
            }
        }

        private void ChangeDepthOfField()
        {
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out _hit, _maxFocusDistanse, _layerMask))
            {
                _depthOfField.active = true;
                var range = Vector3.Distance(_hit.transform.position, _mainCamera.transform.position);
                _depthOfField.focusDistance.value = range - 2;
            }
            else
            {
                _depthOfField.active = false;
                _depthOfField.focusDistance.value = _maxFocusDistanse;
                
            }
        }

        private void ChangeVignette()
        {
            if (_playerData.GetHealth() < 100)
            {
                _vignette.color.value = _redColor;
                _vignette.intensity.value = Mathf.Abs(_playerData.GetHealth() / 100 - 1 + 0.1f);
                if (_vignette.intensity.value > _maxHeartVignette)
                {
                    _vignette.intensity.value = _maxHeartVignette;
                }
            }
            else
            {
                _vignette.color.value = _blackColor;
                _vignette.intensity.value = 0.15f;
            }
        }


    }
}
