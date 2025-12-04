using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SimpleToggle))]
public class VolumeToggler : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private SimpleToggle _simpleToggle;

    private void Awake()
        => _simpleToggle = GetComponent<SimpleToggle>();

    private void Start()
        => Toggle(_simpleToggle.IsOn);

    private void OnEnable()
        => _simpleToggle.Toggled += Toggle;

    private void OnDisable()
        => _simpleToggle.Toggled -= Toggle;

    private void Toggle(bool isActive)
        => _audioMixer.SetFloat(AudioMixerExposedParameters.MasterVolume, isActive ? AudionMixerValueLevels.Max : AudionMixerValueLevels.Min);
}