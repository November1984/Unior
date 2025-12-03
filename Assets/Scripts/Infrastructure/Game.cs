using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private NetAnimator _nets;
    [SerializeField] private Board _board;
    [SerializeField] private ObstaclesSpawner _obstaclesSpawner;
    [SerializeField] private BulletPool _bulletSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _restatScreen;
    [SerializeField] private InputReader _inputReader;

    private void OnEnable()
    {
        _board.Crashed += Stop;
        _startScreen.PlayButtonClicked += LaunchGame;
        _restatScreen.RestartButtonClicked += LaunchGame;
        _inputReader.Tapped += LaunchAnimation;
    }

    private void OnDisable()
    {
        _board.Crashed -= Stop;
        _startScreen.PlayButtonClicked -= LaunchGame;
        _restatScreen.RestartButtonClicked -= LaunchGame;
        _inputReader.Tapped -= LaunchAnimation;
    }

    private void Start()
    {
        _startScreen.gameObject.SetActive(true);
        _restatScreen.gameObject.SetActive(false);
    }

    private void LaunchGame()
    {
        _inputReader.Ride = true;
        _board.Launch();
        _obstaclesSpawner.Launch();
        _startScreen.gameObject.SetActive(false);
        _restatScreen.gameObject.SetActive(false);
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
        _restatScreen.gameObject.SetActive(true);
    }
}