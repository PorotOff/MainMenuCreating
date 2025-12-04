using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class SoundPad : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
        => _button.onClick.AddListener(PlayOneshot);

    private void OnDisable()
        => _button.onClick.RemoveListener(PlayOneshot);

    private void PlayOneshot()
        =>  _audioSource.PlayOneShot(_audioSource.clip);
}