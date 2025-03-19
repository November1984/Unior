using UnityEngine;


// Добавить шанс на разделение кубов, который с каждым кликом уменьшается вдваое

public class CubesGenerator : MonoBehaviour
{
    [SerializeField] private int _maximumCubesCount = 6;
    [SerializeField] private string _physicsMaterialName = "BouncyMaterial";
    private System.Random _randomCount;
    private bool _canCreate;
    private Vector3 _sourceObjectPosition;
    private Vector3 _sourceObjectLocalScale;

    private void Start()
    {
        _randomCount = new();
        _canCreate = false;
    }

    private void Update()
    {
        if (_canCreate)
        {
            Create();
            _canCreate = false;
        }
    }

    private void OnEnable()
    {
        DestroyEventManager.CubeDestroyed += AllowCreate;
    }

    private void OnDisable()
    {
        DestroyEventManager.CubeDestroyed -= AllowCreate;
    }

    private void AllowCreate(GameObject destoryedObject)
    {
        _sourceObjectPosition = destoryedObject.transform.position;
        _sourceObjectLocalScale = destoryedObject.transform.localScale;
        _canCreate = true;
    }

    private void Create()
    {
        int newCubesCount = GetRandomValue(_maximumCubesCount);

        for (int i = 0; i <= newCubesCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = _sourceObjectPosition + GetAxis() * i;
            cube.transform.Translate(GetAxis());
            cube.transform.localScale = _sourceObjectLocalScale / 2;
            cube.AddComponent<Destroyer>();
            cube.AddComponent<ColorAssigner>();
            BoxCollider boxCollider = cube.AddComponent<BoxCollider>();
            PhysicsMaterial customMaterial = Resources.Load<PhysicsMaterial>(_physicsMaterialName);
            boxCollider.material = customMaterial;
            cube.AddComponent<Rigidbody>();
        }
    }

    private UnityEngine.Vector3 GetAxis()
    {
        int axisNumber = GetRandomValue(6);

        return axisNumber switch
        {
            0 => UnityEngine.Vector3.right,
            1 => UnityEngine.Vector3.left,
            2 => UnityEngine.Vector3.up,
            3 => UnityEngine.Vector3.down,
            4 => UnityEngine.Vector3.back,
            _ => UnityEngine.Vector3.forward,
        };
    }

    private int GetRandomValue(int maxValue, int minValue = 1)
    {
        return _randomCount.Next(minValue, maxValue);
    }
}