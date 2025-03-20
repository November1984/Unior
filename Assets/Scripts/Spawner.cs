using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _maximumCubesCount = 6;
    [SerializeField] private string _physicsMaterialName = "BouncyMaterial";
    private int _nextGenerationChance;
    private Raycaster _raycasterComponent;

    private void OnEnable()
    {
        GameObject raycaster = GameObject.Find("Raycaster");
        _raycasterComponent = raycaster.GetComponent<Raycaster>();

        _raycasterComponent.CubeDestroyed += DestroyCube;
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

        GameObject prefab = Resources.Load<GameObject>("Prefabs/CFXR Explosion 1");

        int newCubesCount = GetRandomValue(_maximumCubesCount);

        for (int i = 0; i <= newCubesCount; i++)
        {
            GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            newObject.transform.position = destoryedCube.transform.position;
            newObject.transform.localScale = destoryedCube.transform.localScale / 2;

            ColorAssigner colorAssigner = new();
            Renderer renderer = newObject.GetComponent<Renderer>();
            renderer.material.color = colorAssigner.GetRandomColor();

            PhysicsMaterial customMaterial = Resources.Load<PhysicsMaterial>(_physicsMaterialName);
            BoxCollider boxCollider = newObject.AddComponent<BoxCollider>();
            boxCollider.material = customMaterial;

            Cube newObjectCube = newObject.AddComponent<Cube>();
            newObjectCube.SetNextGenerationChance(_nextGenerationChance);
            newObjectCube.SetEffect(prefab.GetComponent<ParticleSystem>());

            newObject.AddComponent<Rigidbody>();

            newCubes.Add(newObject.GetComponent<Rigidbody>());
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
        Cube destroyedCube = destroyedObject.GetComponent<Cube>();

        destroyer.ExplodeCube(destroyedObject, SpawnCubes(destroyedCube));
    }
}