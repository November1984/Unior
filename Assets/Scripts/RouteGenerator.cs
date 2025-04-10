using System.Collections.Generic;
using UnityEngine;

public class RouteGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] _waipoints;

    private Dictionary<int, List<int>> _routes;
    private void Awake()
    {
        _routes = new Dictionary<int, List<int>>();
        CreateRoutes();
    }

    public List<Vector3> GetRoute()
    {
        int routeNumber = GetRandomRouteNumber();

        List<Vector3> route = new();

        foreach (int point in _routes[routeNumber])
            route.Add(_waipoints[point].position);

        return route;
    }

    private int GetRandomRouteNumber()
    {
        int routesCount = _routes.Count;
        return Random.Range(0, routesCount - 1);
    }

    private void CreateRoutes()
    {
        _routes.Add(0, new List<int>(){5,4,2,7,8});
        _routes.Add(1, new List<int>(){5,4,1,6,8});
        _routes.Add(2, new List<int>(){8,7,2,4,5});
        _routes.Add(3, new List<int>(){8,6,1,4,5});
        // _routes[0].AddRange(new int[] {});
    }
}