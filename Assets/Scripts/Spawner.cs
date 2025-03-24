using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const string MaterialName = "BouncyMaterial";
    private const int ChanceDevider = 2;
    private const int SizeDevider = 2;

    [SerializeField] private int _maximumCubesCount = 6;
    [SerializeField] private List<Cube> _currentCubes;
    [SerializeField] private string _physicsMaterialName = MaterialName;

    private int _nextGenerationChance;
    private Effector _prefab;

    private void OnEnable()
    {
        foreach (Cube cube in _currentCubes)
            cube.CubeDestroyed += DestroyCube;

        _prefab = new();
    }

    private void OnDisable()
    {
        foreach (Cube cube in _currentCubes)
            if (cube != null)
                cube.CubeDestroyed -= DestroyCube;
    }

    private bool IsSuccessfullChance(int chance)
    {
        return GetRandomValue(100) <= chance;
    }

    private List<Rigidbody> SpawnCubes(Cube destoryedCube)
    {
        if (IsSuccessfullChance(destoryedCube.NextGenerationChance) == false)
            return null;

        _nextGenerationChance = destoryedCube.NextGenerationChance / ChanceDevider;

        List<Rigidbody> newCubes = new();

        int newCubesCount = GetRandomValue(_maximumCubesCount);

        for (int i = 0; i <= newCubesCount; i++)
        {
            GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            SetParametersFromDestroyedCube(newObject, destoryedCube);

            SetColor(newObject);

            SetMaterial(newObject);

            SetNextGenerationChance(newObject);

            if (TryAddRigidbody(newObject, out Rigidbody component))
                newCubes.Add(component);
        }

        return newCubes;
    }

    private void SetParametersFromDestroyedCube(GameObject newObject, Cube destoryedCube)
    {
        newObject.transform.position = destoryedCube.transform.position;
        newObject.transform.localScale = destoryedCube.transform.localScale / SizeDevider;
    }

    private void SetColor(GameObject newObject)
    {
        ColorAssigner colorAssigner = new();

        if (newObject.TryGetComponent<Renderer>(out Renderer renderer))
            renderer.material.color = colorAssigner.GetRandomColor();
        else
            Debug.Log("Не создаётся Renderer");
    }

    private void SetMaterial(GameObject newObject)
    {
        PhysicsMaterial customMaterial = Resources.Load<PhysicsMaterial>(_physicsMaterialName);
        BoxCollider boxCollider = newObject.AddComponent<BoxCollider>();
        boxCollider.material = customMaterial;
    }

    private void SetNextGenerationChance(GameObject newObject)
    {
        Cube newObjectCube = newObject.AddComponent<Cube>();
        newObjectCube.SetNextGenerationChance(_nextGenerationChance);
        newObjectCube.SetEffect(_prefab.GetEffect());
        newObjectCube.CubeDestroyed += DestroyCube;
    }

    private bool TryAddRigidbody(GameObject newObject, out Rigidbody component)
    {
        newObject.AddComponent<Rigidbody>();

        if (newObject.TryGetComponent<Rigidbody>(out component))
            return true;
        else
            Debug.Log("Не создаётся Rigidbody");

        return false;
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