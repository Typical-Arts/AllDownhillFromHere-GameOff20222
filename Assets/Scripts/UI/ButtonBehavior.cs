using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class ButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Color _textColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private float _changeDuration;

    void Start()
    {
        _text.color = _textColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Highlight(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Highlight(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Highlight(true);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Highlight(false);
    }

    void Highlight(bool isHighlighted)
    {
        _text.color = isHighlighted ? _hoverColor : _textColor;
    }
}
