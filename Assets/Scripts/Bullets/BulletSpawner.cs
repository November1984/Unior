using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : ObjectPool<Bullet>
{
    [SerializeField] private List<BulletTerminator> _terminators;

    private void OnEnable()
    {
        foreach (BulletTerminator terminator in _terminators)
            terminator.Terminated += Collect;
    }

    private void OnDisable()
    {
        foreach (BulletTerminator terminator in _terminators)
            terminator.Terminated -= Collect;
    }

    private void Collect(Bullet obj)
    {
        PutObject(obj);
    }
}