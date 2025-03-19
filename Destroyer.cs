using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;
    [SerializeField] public int NextGenerationChance { get; private set; } = 100;
    private ParticleSystem _effect;
    private CubesGenerator _cubeGenerator;

    public void SetNextGenerationChance(int value)
    {
        NextGenerationChance = value;
    }

    private void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/CFXR Explosion 1");
        _effect = prefab.GetComponent<ParticleSystem>();
    }

    private void OnMouseDown()
    {
        _cubeGenerator = GetComponent<CubesGenerator>();

        Explode(_cubeGenerator.Create(gameObject));
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explode(List<Rigidbody> explodableObjects)
    {
        if (explodableObjects != null)
            foreach (Rigidbody explodableObject in explodableObjects)
                explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}
