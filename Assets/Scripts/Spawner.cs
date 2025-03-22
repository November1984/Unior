using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _maximumCubesCount = 6;
    [SerializeField] private string _physicsMaterialName = "BouncyMaterial";
    private int _nextGenerationChance;
    private Raycaster _raycasterComponent;
    private Effector _prefab;

    private void OnEnable()
    {
        GameObject raycaster = GameObject.Find("Raycaster");

        if (raycaster.TryGetComponent<Raycaster>(out _raycasterComponent))
            _raycasterComponent.CubeDestroyed += DestroyCube;
        else
            Debug.Log("Не могу получить Raycaster");

        _prefab = new();
    }

    private void OnDisable()
    {
        _raycasterComponent.CubeDestroyed -= DestroyCube;
    }

    private bool IsSuccessfullChance(int chance)
    {
        return GetRandomValue(100) <= chance;
    }

    private List<Rigidbody> SpawnCubes(Cube destoryedCube)
    {
        if (IsSuccessfullChance(destoryedCube.NextGenerationChance) == false)
            return null;

        _nextGenerationChance = destoryedCube.NextGenerationChance / 2;

        List<Rigidbody> newCubes = new();

        int newCubesCount = GetRandomValue(_maximumCubesCount);

        for (int i = 0; i <= newCubesCount; i++)
        {
            GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            newObject.transform.position = destoryedCube.transform.position;
            newObject.transform.localScale = destoryedCube.transform.localScale / 2;

            ColorAssigner colorAssigner = new();

            if (newObject.TryGetComponent<Renderer>(out Renderer renderer))
                renderer.material.color = colorAssigner.GetRandomColor();
            else
                Debug.Log("Не создаётся Renderer");

            PhysicsMaterial customMaterial = Resources.Load<PhysicsMaterial>(_physicsMaterialName);
            BoxCollider boxCollider = newObject.AddComponent<BoxCollider>();
            boxCollider.material = customMaterial;

            Cube newObjectCube = newObject.AddComponent<Cube>();
            newObjectCube.SetNextGenerationChance(_nextGenerationChance);
            newObjectCube.SetEffect(_prefab.GetEffect());

            newObject.AddComponent<Rigidbody>();

            if (newObject.TryGetComponent<Rigidbody>(out Rigidbody component))
                newCubes.Add(component);
            else
                Debug.Log("Не создаётся Rigidbody");
        }

        return newCubes;
    }

    private int GetRandomValue(int maxValue, int minValue = 1)
    {
        System.Random randomCount = new();

        return randomCount.Next(minValue, maxValue);
    }

    private void DestroyCube(GameObject destroyedObject)
    {
        Destroyer destroyer = new();

        if (destroyedObject.TryGetComponent<Cube>(out Cube destroyedCube))
            destroyer.ExplodeCube(destroyedObject, SpawnCubes(destroyedCube));
    }
}