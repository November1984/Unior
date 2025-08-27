using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartPause);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartPause);
    }

    public void StartPause()
    {
        if (_audioSource.isPlaying)
            _audioSource.Pause();
        else
            _audioSource.Play();
    }
}
