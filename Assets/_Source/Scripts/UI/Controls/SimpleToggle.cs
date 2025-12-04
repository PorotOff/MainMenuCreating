using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]

[RequireComponent(typeof(Button))]
public class SimpleToggle : MonoBehaviour
{
    [SerializeField] private Image _isOnImage;
    [SerializeField] private Image _isOffImage;

    private Button _button;

    public event Action<bool> Toggled;

    [field: SerializeField] public bool IsOn { get; private set; }

    private void OnValidate()
        => ToggleImages();

    private void Awake()
        => _button = GetComponent<Button>();

    private void OnEnable()
        => _button.onClick.AddListener(Toggle);

    private void OnDisable()
        => _button.onClick.RemoveListener(Toggle);

    private void Toggle()
    {
        if (_isOnImage != null && _isOffImage != null)
        {
            IsOn = !IsOn;
            ToggleImages();

            Toggled?.Invoke(IsOn);
        }
    }

    private void ToggleImages()
    {
        if (IsOn)
        {
            _isOnImage.gameObject.SetActive(true);
            _isOffImage.gameObject.SetActive(false);
        }
        else
        {
            _isOnImage.gameObject.SetActive(false);
            _isOffImage.gameObject.SetActive(true);
        }
    }
}