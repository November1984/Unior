using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    private const float SpawnHeight = 6;

    [SerializeField, Min(0.01f)] private float _repeateRate = 0.1f;
    [SerializeField] private float _minSpawnCoordinate = -3;
    [SerializeField] private float _maxSpawnCoordinate = 3;
    
    private ColorChanger _colorChanger;

    protected override void Start()
    {
        base.Start();
        
        InvokeRepeating(nameof(GetObj), 0.0f, _repeateRate);
        _colorChanger = new();
    }

    protected override Cube Create()
    {
        Cube obj = base.Create();

        obj.CollisionOccurred += _colorChanger.PaintRed;

        return obj;
    }

    protected override void ActionOnGet(IPoolable obj)
    {
        obj.Init();
        
        obj.Transform.position = new Vector3(
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate),
            SpawnHeight,
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate)
            );
        obj.Rigidbody.linearVelocity = Vector3.zero;
        
        obj.Transform.gameObject.SetActive(true);
        
        SpawnedCount++;
    }
}