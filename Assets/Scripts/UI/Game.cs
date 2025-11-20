using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private NetAnimator _nets;
    [SerializeField] private Board _board;
    [SerializeField] private StartButton _startButton;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private ObstaclesSpawner _obstaclesSpawner;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private StartMenu _startMenu;
    [SerializeField] private RestartMenu _restatMenu;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _board.Crashed += Stop;
        _startButton.Clicked += LaunchGame;
        _restartButton.Clicked += LaunchGame;
        _inputReader.Tapped += LaunchAnimation;
    }

    private void OnDisable()
    {
        _board.Crashed -= Stop;
        _startButton.Clicked -= LaunchGame;
        _restartButton.Clicked -= LaunchGame;
        _inputReader.Tapped -= LaunchAnimation;
    }

    private void Start()
    {
        _startMenu.gameObject.SetActive(true);
        _restatMenu.gameObject.SetActive(false);
    }

    private void LaunchGame()
    {
        _inputReader.Ride = true;
        _board.Launch();
        _obstaclesSpawner.Launch();
        _startMenu.gameObject.SetActive(false);
        _restatMenu.gameObject.SetActive(false);
    }

    private void LaunchAnimation()
    {
        _nets.Launch();
    }

    private void Stop()
    {
        _inputReader.Ride = false;
        _nets.Stop();
        _obstaclesSpawner.Stop();
        _bulletSpawner.Reset();
        _restatMenu.gameObject.SetActive(true);
    }
}