using System.Collections;
using System.Linq;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _spawns;
    [SerializeField] private int _enemies = 1;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay = 1f;

    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }

    private IEnumerator Start()
    {
        for (int i = 0; i < _enemies; i++)
        {
            yield return _wait;

            Enemy enemy = Instantiate(_enemyPrefab, _spawns.GetChild(i).transform.position, Quaternion.identity);
            enemy.Initialize(new Path(_path.Cast<Transform>()));
            enemy.gameObject.SetActive(true);
        }
    }
}