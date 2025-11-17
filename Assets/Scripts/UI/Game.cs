using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Nets _nets;
    [SerializeField] private Board _board;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private ObstaclesSpawner _obstaclesSpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private RestartMenu _restatMenu;

    private void OnEnable()
    {
        _board.Crashed += Stop;
        _startButton.Clicked += Launch;
        _restartButton.Clicked += Launch;
    }

    private void OnDisable()
    {
        _board.Crashed -= Stop;
        _startButton.Clicked -= Launch;
        _restartButton.Clicked -= Launch;
    }

    private void Start()
    {
        _startMenu.gameObject.SetActive(true);
        _restatMenu.gameObject.SetActive(false);
    }

    private void Launch()
    {
        _nets.Launch();
        _board.Launch();
        _obstaclesSpawner.Launch();
        _startMenu.gameObject.SetActive(false);
        _restatMenu.gameObject.SetActive(false);
    }

    private void Stop()
    {
        _nets.Stop();
        _obstaclesSpawner.Stop();
        _bulletSpawner.Reset();
        _restatMenu.gameObject.SetActive(true);
    }
}