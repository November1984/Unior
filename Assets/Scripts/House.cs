using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeStep = 0.004f;
    [SerializeField] private float _maxVolume = 1f;

    private bool _isAlarm;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _isAlarm = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SwitchAlarmOn();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isAlarm = false;
    }

    private void Update()
    {
        if (_isAlarm == true && _audioSource.volume < 1)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeStep);
        else if (_isAlarm == false && _audioSource.volume > 0)
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _volumeStep);
        else if (_audioSource.isPlaying && _audioSource.volume == 0)
            _audioSource.Stop();
    }

    private void SwitchAlarmOn()
    {
        _isAlarm = true;
        _audioSource.volume = 0;
        _audioSource.Play();
    }
}