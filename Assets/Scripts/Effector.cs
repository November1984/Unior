using System.Collections;
using UnityEngine;

public class Effector
{
    private GameObject _prefab;

    public Effector()
    {
        _prefab = Resources.Load<GameObject>("Prefabs/CFXR Explosion 1");
    }

    public ParticleSystem GetEffect()
    {
        if (_prefab.TryGetComponent<ParticleSystem>(out ParticleSystem component))
            return component;
        
        return null;
    }
}
