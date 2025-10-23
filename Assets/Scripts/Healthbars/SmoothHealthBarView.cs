using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Healthbars
{
    [RequireComponent(typeof(Slider))]
    public class SmoothHealthBarView : HealthView
    {
        [SerializeField] private float _fillingDelay = 0.001f;
        [SerializeField] private float _fillingStep = 1f;

        private Coroutine _coroutine;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        protected override void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            base.OnDisable();
        }

        protected override void Change(float value, float delta)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(RunChanger(value));
        }

        private IEnumerator RunChanger(float newValue)
        {
            var wait = new WaitForSecondsRealtime(_fillingDelay);

            while (_slider.value != newValue)
            {
                _slider.value = Mathf.MoveTowards(_slider.value, newValue, _fillingStep);

                _fillingStep = Mathf.Max(Mathf.Abs(_slider.value - newValue) * Time.deltaTime, 0.2f);

                yield return wait;
            }
        }
    }
}