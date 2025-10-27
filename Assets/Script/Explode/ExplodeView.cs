using UnityEngine;

public class ExplodeView : MonoBehaviour
{
        [SerializeField] private ParticleSystem _effect;

        public void Show()
        {
                Instantiate(_effect, transform.position, transform.rotation);
        }

}