using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SliderBehavior : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private SelectableButton _sliderSelectableButton;
    [SerializeField] private TMP_Text _labelText;
    [SerializeField] private Color selectedColor;

    private Color _defaultColor;

    private void Start()
    {
        _defaultColor = _labelText.color;
    }

    public void OnValueChanged(UnityAction<float> action)
    {
        _slider.onValueChanged.AddListener(action);
        _sliderSelectableButton.selected += HandleSelect;
        _sliderSelectableButton.deselected += HandleDeselect;
    }

    public void SetValue(float value)
    {
        _slider.value = Mathf.Clamp(value, 0f, 1f);
    }

    private void HandleSelect()
    {
        _labelText.color = selectedColor;
    }

    private void HandleDeselect()
    {
        _labelText.color = _defaultColor;
    }
}
