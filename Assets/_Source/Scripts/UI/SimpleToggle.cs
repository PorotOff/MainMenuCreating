using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]

[RequireComponent(typeof(Button))]
public class SimpleToggle : MonoBehaviour
{
    [SerializeField] private bool _isActive;
    [SerializeField] private Image _onActiveImage;
    [SerializeField] private Image _onNotActiveImage;

    private Button _button;

    public event Action<bool> Toggled;

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
        if (_onActiveImage != null && _onNotActiveImage != null)
        {
            _isActive = !_isActive;
            ToggleImages();

            Toggled?.Invoke(_isActive);
        }
    }

    private void ToggleImages()
    {
        if (_isActive)
        {
            _onActiveImage.gameObject.SetActive(true);
            _onNotActiveImage.gameObject.SetActive(false);
        }
        else
        {
            _onActiveImage.gameObject.SetActive(false);
            _onNotActiveImage.gameObject.SetActive(true);
        }
    }
}