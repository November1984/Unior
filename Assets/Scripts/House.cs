using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeStep = 0.004f;
    [SerializeField] private float _maxAlarmVolume = 1f;

    private Notifier _notifier;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _notifier = GetComponent<Notifier>();
    }

    private void OnEnable()
    {
        _notifier.ObjectIndoored += SwitchAlarm;
        _notifier.ObjectOutdoored += SwitchAlarm;
    }

    private void OnDisable()
    {
        _notifier.ObjectIndoored -= SwitchAlarm;
        _notifier.ObjectOutdoored -= SwitchAlarm;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator Alarm(float alarmTargetVolume)
    {
        _audioSource.Play();

        while (_audioSource.volume != alarmTargetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, alarmTargetVolume, _volumeStep);

            yield return 0;
        }

        if (_audioSource.isPlaying && _audioSource.volume == 0)
            _audioSource.Stop();
    }

    private void SwitchAlarm(Thieft fool = null)
    {
        float targetVolume = 0;

        if (fool != null)
        {
            _audioSource.volume = 0;
            targetVolume = _maxAlarmVolume;
        }

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Alarm(targetVolume));
    }
}