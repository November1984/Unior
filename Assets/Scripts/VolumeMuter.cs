using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class VolumeMuter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private Button _button;
    private bool _isMuting;
    private float _currentVolumeLevel;

    public void Awake()
    {
        _button = GetComponent<Button>();
        _isMuting = false;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Mute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Mute);
    }

    public void Mute()
    {
        float newVolumeLevel;
        const float MinimumValue = -80f;

        newVolumeLevel = _isMuting ? _currentVolumeLevel : MinimumValue;
        _isMuting = !_isMuting;

        _audioMixer.GetFloat(_audioMixer.name, out _currentVolumeLevel);
        _audioMixer.SetFloat(_audioMixer.name, newVolumeLevel);
    }
}