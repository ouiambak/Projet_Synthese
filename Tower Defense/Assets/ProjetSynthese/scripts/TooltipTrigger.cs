using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string tooltipMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 mousePosition = Input.mousePosition;
        TooltipUI tooltip = TooltipUI.Instance;
        if (tooltip != null)
        {
            tooltip.Show(tooltipMessage, mousePosition);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI tooltip = TooltipUI.Instance;
        if (tooltip != null)
        {
            tooltip.Hide();
        }
    }
}
