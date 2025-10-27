using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 80f;
    [SerializeField] private float _explosionForce = 100f;
    [SerializeField] private ExplodeView _explodeView;
    [SerializeField] private LayerMask _layerMask;

    Collider[] _hitObjects = new Collider[30];


    public void Explode()
    {
        _explodeView.Show();
        
        int hitsCount = Physics.OverlapSphereNonAlloc(transform.position, _explosionRadius, _hitObjects, _layerMask);

        for (int i = 0; i < hitsCount; i++)
            _hitObjects[i].attachedRigidbody?.AddExplosionForce(_explosionForce,
                                                                transform.position,
                                                                _explosionRadius
                                                              );
    }
}
