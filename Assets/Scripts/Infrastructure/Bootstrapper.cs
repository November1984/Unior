using System.Collections;
using System.Linq;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _enemySpawns;
    [SerializeField] private Transform _playerSpawn;
    [SerializeField] private int _enemies = 1;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private float _delay = 1f;

    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }

    private IEnumerator Start()
    {
        Player player = Instantiate(_playerPrefab, _playerSpawn.position, Quaternion.identity);
        
        player.Initialize();
        player.gameObject.SetActive(true);
        
        for (int i = 0; i < _enemies; i++)
        {
            yield return _wait;

            Vector3 position = (_enemySpawns.childCount > 0) ? _enemySpawns.GetChild(i).transform.position : _enemySpawns.position;

            Enemy enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);

            enemy.Initialize(new Path(_path.Cast<Transform>()));
            enemy.gameObject.SetActive(true);
        }
    }
}