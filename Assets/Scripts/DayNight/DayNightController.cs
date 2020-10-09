using UnityEngine;


namespace Shipov_FP_Adventure
{
    public sealed class DayNightController : MonoBehaviour
    {
        #region Constants

        private const float HALF_DAY = 0.5f;
        private const float FULL_DAY = 1.0f;
        private const int HALF_CIRCLE = 180;
        private const int FULL_CIRCLE = 360;

        #endregion


        #region Fields

        [SerializeField] private Light _lightDaySource;
        [SerializeField] private Light _lightNightSource;

        [SerializeField] private AnimationCurve _dayLightCurve;
        [SerializeField] private AnimationCurve _nightLightCurve;
        [SerializeField] private AnimationCurve _skyBoxCurve;

        [SerializeField] private Material _daySkybox;
        [SerializeField] private Material _nightSkybox;

        [SerializeField] private float _lengthOfTheDay;
        [SerializeField] private float _currentTime;

        private float _dayLightIntensity;
        private float _nightLightIntensity;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _dayLightIntensity = _lightDaySource.intensity;
            _nightLightIntensity = _lightNightSource.intensity;
        }

        private void Update()
        {
            ChangeTime();

            DayNightCycle();

        }

        #endregion


        #region Methods

        private void DayNightCycle()
        {
            RenderSettings.skybox.Lerp(_nightSkybox, _daySkybox, _skyBoxCurve.Evaluate(_currentTime));

            if (_skyBoxCurve.Evaluate(_currentTime) > HALF_DAY)
            {
                RenderSettings.sun = _lightDaySource;
            }
            else
            {
                RenderSettings.sun = _lightNightSource;
            }

            DynamicGI.UpdateEnvironment();

            _lightDaySource.transform.localRotation = Quaternion.Euler(_currentTime * -FULL_CIRCLE, HALF_CIRCLE, 0);
            _lightNightSource.transform.localRotation = Quaternion.Euler(_currentTime * -FULL_CIRCLE + HALF_CIRCLE, HALF_CIRCLE, 0);
            _lightDaySource.intensity = _dayLightIntensity * _dayLightCurve.Evaluate(_currentTime);
            _lightNightSource.intensity = _nightLightIntensity * _nightLightCurve.Evaluate(_currentTime);
        }

        private void ChangeTime()
        {
            _currentTime += Time.deltaTime / _lengthOfTheDay;
            if (_currentTime >= FULL_DAY)
            {
                _currentTime = 0;
            }
        }

        #endregion
    }
}
