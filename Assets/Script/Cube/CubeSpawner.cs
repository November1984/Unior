using System.Collections;
using UnityEngine;

public class CubeSpawner : Spawner<Cube>
{
    private const float SpawnHeight = 6;

    [SerializeField, Min(0.01f)] private float _repeateRate = 0.1f;
    [SerializeField] private float _minSpawnCoordinate = -3;
    [SerializeField] private float _maxSpawnCoordinate = 3;
    [SerializeField] private BombSpawner _bombSpawner;
    
    private ColorChanger _colorChanger;
    private Coroutine _coroutine;

    protected override void Start()
    {
        base.Start();

        _colorChanger = new();
        _coroutine = StartCoroutine(Generate());
        ObjCollected += CreateBomb;
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
        obj.Reset();

        obj.Transform.position = new Vector3(
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate),
            SpawnHeight,
            Random.Range(_minSpawnCoordinate, _maxSpawnCoordinate)
            );

        obj.Transform.gameObject.SetActive(true);

        SpawnedCount++;
    }

    private void OnDisable()
    {
        ObjCollected -= CreateBomb;
        
        if (_coroutine != null)
        StopCoroutine(_coroutine);
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSecondsRealtime(_repeateRate);

        while (true)
        {
            GetObj();
            yield return wait;
        }
    }

    private void CreateBomb(IPoolable obj)
    {
        _bombSpawner?.CreateBomb(obj.Transform.position);
    }
}