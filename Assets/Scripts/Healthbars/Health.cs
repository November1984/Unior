using System;
using UnityEngine;
namespace Healthbars
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _startValue = 50f;
        [SerializeField] private float _maxValue = 100;
        [SerializeField] private float _minValue = 0f;

        public event Action<float, float> Changed;

        public float CurrentValue { get; private set; }
        public float Max => _maxValue;

        private void Awake()
        {
            CurrentValue = _startValue;
        }

        public void Increase(float delta)
        {
            float newValue = CurrentValue + delta;

            CurrentValue = Mathf.Clamp(newValue, _minValue, _maxValue);

            Changed?.Invoke(CurrentValue, delta);
        }

        public void Decrease(float delta)
        {
            float newValue = CurrentValue - delta;

            CurrentValue = Mathf.Clamp(newValue, _minValue, _maxValue);

            Changed?.Invoke(CurrentValue, -delta);
        }
    }
}