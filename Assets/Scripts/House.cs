using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class House : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeStep = 0.004f;
    [SerializeField] private float _maxVolume = 1f;

    private bool _isAlarm;
    private Notifier _notifier;
    private Coroutine _coroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _notifier = GetComponent<Notifier>();
        _isAlarm = false;
        _notifier._isIndoors += SwitchAlarmOn;
        _notifier._isOutdoors += SwitchAlarmOff;
    }

    private void OnDisable()
    {
        _notifier._isIndoors -= SwitchAlarmOn;
        _notifier._isOutdoors -= SwitchAlarmOff;
    }

    private IEnumerator Alarm()
    {
        _audioSource.Play();

        while (_isAlarm || _audioSource.isPlaying)
        {
            if (_isAlarm == true && _audioSource.volume < 1)
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _volumeStep);
            else if (_isAlarm == false && _audioSource.volume > 0)
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _volumeStep);
            else if (_audioSource.isPlaying && _audioSource.volume == 0)
            {
                _audioSource.Stop();
                StopCoroutine(_coroutine);
            }

            yield return 0;
        }
    }

    private void SwitchAlarmOn(Transform obj)
    {
        if (obj.TryGetComponent<Thieft>(out Thieft fool))
        {
            _isAlarm = true;
            _audioSource.volume = 0;
            _coroutine = StartCoroutine(Alarm());
        }
    }

    private void SwitchAlarmOff()
    {
        _isAlarm = false;
    }
}