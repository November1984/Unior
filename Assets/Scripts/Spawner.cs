using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnEnable()
    {
        foreach (Cube cube in _currentCubes)
            cube.CubeDestroyed += DestroyCube;
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

            SetMaterial(newObject);

            SetNextGenerationChance(newObject);

            EditRigidbody(newObject, out Rigidbody component);

            newCubes.Add(component);
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
        ColorAssigner colorAssigner = new();

        if (newObject.TryGetComponent<Renderer>(out Renderer renderer))
            renderer.material.color = colorAssigner.GetRandomColor();
        else
            Debug.Log("Не создаётся Renderer");
    }

    private void SetMaterial(Cube newObject)
    {
        PhysicsMaterial customMaterial = Resources.Load<PhysicsMaterial>(_physicsMaterialName);
        BoxCollider boxCollider = newObject.gameObject.AddComponent<BoxCollider>();
        boxCollider.material = customMaterial;
    }

    private void SetNextGenerationChance(Cube newObject)
    {
        newObject.SetNextGenerationChance(_nextGenerationChance);
        newObject.CubeDestroyed += DestroyCube;
    }

    private void EditRigidbody(Cube newObject, out Rigidbody rigidbodyComponent)
    {
        rigidbodyComponent = newObject.GetComponent<Rigidbody>();
        rigidbodyComponent.useGravity = true;
        rigidbodyComponent.isKinematic = false;

        BoxCollider colliderComponent = newObject.GetComponent<BoxCollider>();
        colliderComponent.size /= SizeDevider;
    }

    private int GetRandomValue(int maxValue, int minValue = 1)
    {
        System.Random randomCount = new();

        return randomCount.Next(minValue, maxValue);
    }

    private void DestroyCube(Cube destroyedCube)
    {
        Exploder exploder = new();

        if (IsSuccessfullChance(destroyedCube.NextGenerationChance))
            exploder.Explode(destroyedCube, SpawnCubes(destroyedCube));
        else
            exploder.Explode(destroyedCube, ScatterCubes(destroyedCube));
    }

    private List<Rigidbody> ScatterCubes(Cube destroyedCube)
    {
        Collider[] hits = Physics.OverlapSphere(destroyedCube.transform.position, destroyedCube.ExplosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}