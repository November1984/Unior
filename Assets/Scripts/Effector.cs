using UnityEngine;

public class Effector
{
    private ParticleSystem _prefab;

    public Effector()
    {
        _prefab = Resources.Load<ParticleSystem>("Prefabs/CFXR Explosion 1");
    }

    public ParticleSystem GetEffect()
    {
        if (_prefab.TryGetComponent<ParticleSystem>(out ParticleSystem component))
            return component;
        
        return null;
    }
}
