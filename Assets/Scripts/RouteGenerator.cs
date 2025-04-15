using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RouteGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] _waipoints;

    private Dictionary<int, List<int>> _routes;

    private void Awake()
    {
        _routes = new Dictionary<int, List<int>>();
        _routes = TempleRoutes();
    }

    public List<Vector3> GetRoute(Vector3 startPosition)
    {
        int spawnPositionNumber = GetSpawnPositionCode(startPosition);
        Dictionary<int, List<int>> activeRoutes = GetActualRoutes(spawnPositionNumber);
        int routeNumber = GetRandomValue(activeRoutes.Count());

        List<Vector3> route = new();

        foreach (int point in activeRoutes[routeNumber])
            route.Add(_waipoints[point].position);

        return route;
    }

    private Dictionary<int, List<int>> GetActualRoutes(int spawnPositionCode)
    {
        Dictionary<int, List<int>> result = new();
        int i = 0;

        foreach (List<int> route in _routes.Values)
        {
            if (route[0] == spawnPositionCode)
            {
                result.Add(i, route);
                i++;
            }
        }

        return result;
    }

    private int GetSpawnPositionCode(Vector3 startPosition)
    {
        float magnitude = Mathf.Infinity;
        int result = 0;

        for (int i = 0; i < _waipoints.Count(); i++)
        {
            float currentMagnitude = Vector3.Distance(_waipoints[i].position, startPosition);

            if (magnitude > currentMagnitude)
            {
                magnitude = currentMagnitude;
                result = i;
            }
        }

        return result;
    }

    private int GetRandomValue(int maxValue)
    {
        return Random.Range(0, maxValue);
    }

    private Dictionary<int, List<int>> TempleRoutes()
    {
        return new Dictionary<int, List<int>>()
        {
            {0, new List<int>() { 5, 4, 2, 7, 8 }},
            {1, new List<int>() { 5, 4, 1, 6, 8 }},
            {2, new List<int>() { 8, 7, 2, 4, 5 }},
            {3, new List<int>() { 8, 6, 1, 4, 5 }}
        };
    }
}