using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int ChanceDevider = 2;
    private const int SizeDevider = 2;

    [SerializeField] private int _maximumCubesCount = 6;
    [SerializeField] private List<Cube> _currentCubes;

    private int _nextGenerationChance;
    private ColorAssigner _colorAssigner;

    private void OnEnable()
    {
        _colorAssigner = new();

        foreach (Cube cube in _currentCubes)
            cube.CubeDestroyed += ExplodeCube;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _currentCubes)
            if (cube != null)
                cube.CubeDestroyed -= ExplodeCube;
    }

    private bool IsSuccessfullChance(int chance)
    {
        return GetRandomValue(100) <= chance;
    }

    private List<Rigidbody> SpawnCubes(Cube destroyedCube)
    {
        _nextGenerationChance = destroyedCube.NextGenerationChance / ChanceDevider;

        List<Rigidbody> newCubes = new();

        int newCubesCount = GetRandomValue(_maximumCubesCount);

        for (int i = 0; i <= newCubesCount; i++)
        {
            Cube newObject = Cube.Instantiate(destroyedCube);

            SetName(newObject, destroyedCube);

            SetParametersFromDestroyedCube(newObject, destroyedCube);

            SetColor(newObject);

            SetNextGenerationChance(newObject);

            EditRigidbody(newObject);

            newCubes.Add(newObject.Rigidbody);
        }

        return newCubes;
    }

    private void SetName(Cube newObject, Cube destoryedCube)
    {
        string[] oldName = destoryedCube.name.Split("_");
        int genNumber = Int32.Parse(oldName[2]) + 1;

        newObject.name = oldName[0] + "_" + oldName[1] + "_" + genNumber;
    }

    private void SetParametersFromDestroyedCube(Cube newObject, Cube destoryedCube)
    {
        newObject.transform.position = destoryedCube.transform.position;
        newObject.transform.localScale = destoryedCube.transform.localScale / SizeDevider;

        newObject.IncreaseExplosionForce();
        newObject.IncreaseExplosionRadius();
    }

    private void SetColor(Cube newObject)
    {
        if (newObject.TryGetComponent<Renderer>(out Renderer renderer))
            renderer.material.color = _colorAssigner.GetRandomColor();
        else
            Debug.Log("Не создаётся Renderer");
    }

    private void SetNextGenerationChance(Cube newObject)
    {
        newObject.SetNextGenerationChance(_nextGenerationChance);
        newObject.CubeDestroyed += ExplodeCube;
    }

    private void EditRigidbody(Cube newObject)
    {
        newObject.Rigidbody.useGravity = true;
        newObject.Rigidbody.isKinematic = false;
    }

    private int GetRandomValue(int maxValue, int minValue = 1)
    {
        System.Random randomCount = new();

        return randomCount.Next(minValue, maxValue);
    }

    private void ExplodeCube(Cube destroyedCube)
    {
        Exploder exploder = new();

        destroyedCube.CubeDestroyed -= ExplodeCube;
        
        if (IsSuccessfullChance(destroyedCube.NextGenerationChance))
            exploder.Explode(destroyedCube, SpawnCubes(destroyedCube));
        else
            exploder.Explode(destroyedCube, exploder.ScatterCubes(destroyedCube));
    }

}