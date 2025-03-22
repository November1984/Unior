using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public float ExplosionRadius { get; private set; } = 20f;
    public float ExplosionForce { get; private set; } = 700f;
    public int NextGenerationChance { get; private set; } = 100;

    private void OnMouseDown()
    {
        GameObject raycaster = GameObject.Find("Raycaster");

        if (raycaster.TryGetComponent<Raycaster>(out Raycaster raycasterComponent))
            raycasterComponent.DestroyedNotify(gameObject);
        else
            Debug.Log("Не создаётся Raycaster");
    }

    public void SetEffect(ParticleSystem value)
    {
        _effect = value;
    }

    public void SetNextGenerationChance(int value)
    {
        NextGenerationChance = value;
    }

    public void Destroy()
    {
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
