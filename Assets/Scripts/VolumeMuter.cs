using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class VolumeMuter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    private Button _button;
    private bool _isMuting;

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
        float valueLevel;
        const float MinimumValue = -80f;
        const float MaximumValue = 0;

        valueLevel = _isMuting ? MaximumValue : MinimumValue;
        _isMuting = !_isMuting;

        _audioMixerGroup.audioMixer.SetFloat(_audioMixerGroup.name, valueLevel);
    }
}