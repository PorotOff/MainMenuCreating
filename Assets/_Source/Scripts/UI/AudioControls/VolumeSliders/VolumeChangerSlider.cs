using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class VolumeChangerSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private Slider _slider;

    protected abstract string AudioMixerParameter { get; }

    private void Awake()
        => _slider = GetComponent<Slider>();

    private void Start()
        => SetVolume(_slider.value);

    private void OnEnable()
        => _slider.onValueChanged.AddListener(SetVolume);

    private void OnDisable()
        => _slider.onValueChanged.RemoveListener(SetVolume);

    private void SetVolume(float value)
    {
        float volume = value > 0 ? 20 * Mathf.Log10(value) : AudionMixerValueLevels.Min;
        _audioMixer.SetFloat(AudioMixerParameter, volume);
    }
}