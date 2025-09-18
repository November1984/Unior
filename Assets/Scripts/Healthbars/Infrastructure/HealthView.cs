using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Healthbars
{
    public abstract class HealthView : MonoBehaviour
    {
        [SerializeField] protected Health Health;

        private void Start()
        {
            Change(Health.CurrentValue, 0);
        }

        public Health GetHealth()
        {
            return Health;
        }

        protected void OnEnable()
        {
            Health.Changed += Change;
        }

        protected virtual void OnDisable()
        {
            Health.Changed -= Change;
        }

        protected abstract void Change(float value, float delta);
    }
}