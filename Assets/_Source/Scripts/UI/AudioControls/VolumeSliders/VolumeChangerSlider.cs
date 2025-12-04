using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChangerSlider : MonoBehaviour
{
    private const float MinSliderValue = 0f;
    private const float MaxSliderValue = 1f;
    private const float LogToDBCoefficient = 20f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _audioMixerParameter;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();

        _slider.minValue = MinSliderValue;
        _slider.maxValue = MaxSliderValue;
    }

    private void Start()
        => SetVolume(_slider.value);

    private void OnEnable()
        => _slider.onValueChanged.AddListener(SetVolume);

    private void OnDisable()
        => _slider.onValueChanged.RemoveListener(SetVolume);

    private void SetVolume(float value)
    {
        float volume = value > MinSliderValue ? LogToDBCoefficient * Mathf.Log10(value) : AudionMixerValueLevels.Min;
        _audioMixer.SetFloat(_audioMixerParameter, volume);
    }
}