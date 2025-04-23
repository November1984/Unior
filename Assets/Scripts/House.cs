using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeStep = 0.004f;
    [SerializeField] private float _maxAlarmVolume = 1f;

    private bool _isAlarm;
    private Notifier _notifier;
    private Coroutine _coroutine;
    private float _alarmTargetVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _notifier = GetComponent<Notifier>();
        _isAlarm = false;
    }

    private void OnEnable()
    {
        _notifier.ObjectIndoored += SwitchAlarmOn;
        _notifier.ObjectOutdoored += SwitchAlarmOff;
    }

    private void OnDisable()
    {
        _notifier.ObjectIndoored -= SwitchAlarmOn;
        _notifier.ObjectOutdoored -= SwitchAlarmOff;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Alarm()
    {
        _audioSource.Play();

        while (_isAlarm || _audioSource.isPlaying)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _alarmTargetVolume, _volumeStep);

            if (_audioSource.isPlaying && _audioSource.volume == 0)
            {
                _audioSource.Stop();
                yield break;
            }

            yield return 0;
        }
    }

    private void SwitchAlarmOn()
    {
        _isAlarm = true;
        _audioSource.volume = 0;

        _alarmTargetVolume = _maxAlarmVolume;
        _coroutine = StartCoroutine(Alarm());
    }

    private void SwitchAlarmOff()
    {
        _isAlarm = false;
        _alarmTargetVolume = 0;
    }
}