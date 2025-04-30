using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    public string tooltipMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(" touche moi !!");
        Vector2 mousePosition = Input.mousePosition;
        TooltipUI tooltip = TooltipUI.Instance;
        if (tooltip != null)
        {
            Debug.Log(" Tooltips manager is present !!");
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
