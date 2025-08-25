using UnityEngine;
using UnityEngine.Audio;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    private bool _isMuting;
    private string _mixerName;

    public void Awake()
    {
        _isMuting = false;
    }

    public void Mute()
    {
        float valueLevel;
        const float MinimumValue = -80f;
        const float MaximumValue = 0;

        valueLevel = _isMuting ? MaximumValue : MinimumValue;
        _isMuting = !_isMuting;

        _audioMixer.audioMixer.SetFloat(_mixerName, valueLevel);
    }

    public void SetMixerName(string value)
    {
        _mixerName = value;
    }

    public void ChangeVolume(float value)
    {
        const float SomeCoeff = 20;
        const float MinimumValue = -80f;
        const float MaximumValue = 0;

        _audioMixer.audioMixer.SetFloat(_mixerName, Mathf.Clamp(Mathf.Log10(value) * SomeCoeff,MinimumValue,MaximumValue));
    }
}