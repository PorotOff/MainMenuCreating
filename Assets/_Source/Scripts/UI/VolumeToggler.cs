using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SimpleToggle))]
public class VolumeToggler : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private const float MinAudioMixerValue = -80f;
    private const float MaxAudioMixerValue = 0f;

    private SimpleToggle _simpleToggle;

    private void Awake()
        => _simpleToggle = GetComponent<SimpleToggle>();

    private void OnEnable()
        => _simpleToggle.Toggled += Toggle;

    private void OnDisable()
        => _simpleToggle.Toggled -= Toggle;

    private void Toggle(bool isActive)
        => _audioMixer.SetFloat(AudioMixerExposedParameters.MasterVolume, isActive ? MaxAudioMixerValue : MinAudioMixerValue);
}