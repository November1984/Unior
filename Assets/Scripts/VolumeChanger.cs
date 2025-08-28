using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float value)
    {
        const float SomeCoeff = 20;
        const float MinimumValue = -80f;
        const float MaximumValue = 0;
        
        _audioMixer.SetFloat(_slider.name, Mathf.Clamp(Mathf.Log10(value) * SomeCoeff, MinimumValue, MaximumValue));
    }
}