using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleBehavior : MonoBehaviour
{
    [SerializeField] private Button _toggleButton;
    [SerializeField] private SelectableButton _toggleSelectableButton;
    [SerializeField] private TMP_Text _enabledText;
    [SerializeField] private TMP_Text _labelText;
    [SerializeField] private Color selectedColor;

    private Color _defaultColor;
    private UnityAction _clickAction;

    void Start() 
    {
        _toggleButton.onClick.AddListener(HandleClick);
        _defaultColor = _labelText.color;
        _toggleSelectableButton.selected += HandleSelect;
        _toggleSelectableButton.deselected += HandleDeselect;
    }

    void HandleClick()
    {
        _clickAction.Invoke();
    }

    public void OnToggle(UnityAction action)
    {
        _clickAction += action;
    }

    public void SetValue(bool value)
    {
        _enabledText.enabled = value;
    }

    void HandleSelect()
    {
        _labelText.color = selectedColor;
    }

    void HandleDeselect()
    {
        _labelText.color = _defaultColor;
    }
}
