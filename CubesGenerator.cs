using System;
using System.Collections.Generic;
using UnityEngine;

public class CubesGenerator : MonoBehaviour
{
    [SerializeField] private int _maximumCubesCount = 6;
    [SerializeField] private string _physicsMaterialName = "BouncyMaterial";
    private int _nextGenerationChance;

    private Boolean IsSuccessfullChance()
    {
        return GetRandomValue(100) <= _nextGenerationChance;
    }

    public List<Rigidbody> Create(GameObject destoryedObject)
    {
        Destroyer destroyedObjectComponent = destoryedObject.GetComponent<Destroyer>();
        _nextGenerationChance = destroyedObjectComponent.NextGenerationChance;

        if (IsSuccessfullChance() == false)
            return null;

        List<Rigidbody> cubes = new();

        int newCubesCount = GetRandomValue(_maximumCubesCount);

        _nextGenerationChance /= 2;

        for (int i = 0; i <= newCubesCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = destoryedObject.transform.position;
            cube.transform.localScale = destoryedObject.transform.localScale / 2;

            Destroyer destroyer = cube.AddComponent<Destroyer>();
            destroyer.SetNextGenerationChance(_nextGenerationChance);

            cube.AddComponent<ColorAssigner>();
            cube.AddComponent<CubesGenerator>();

            BoxCollider boxCollider = cube.AddComponent<BoxCollider>();
            PhysicsMaterial customMaterial = Resources.Load<PhysicsMaterial>(_physicsMaterialName);
            boxCollider.material = customMaterial;

            cube.AddComponent<Rigidbody>();

            cubes.Add(cube.GetComponent<Rigidbody>());
        }

        return cubes;
    }

    private int GetRandomValue(int maxValue, int minValue = 1)
    {
        System.Random _randomCount = new();

        return _randomCount.Next(minValue, maxValue);
    }
}