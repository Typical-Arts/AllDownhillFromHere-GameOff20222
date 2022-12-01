using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public UnityAction selected;
    public UnityAction deselected;

    public void OnSelect(BaseEventData eventData)
    {
        if (selected != null)
        {
            selected.Invoke();
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (deselected != null)
        {
            deselected.Invoke();
        }
    }
}
