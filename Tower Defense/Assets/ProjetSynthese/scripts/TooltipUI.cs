using UnityEngine;
using TMPro;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;


    public TextMeshProUGUI tooltipText;
    public RectTransform backgroundRect;

    private void Awake()
    {
        if (Instance == null) { 
            Instance = this;
        }
        else if(Instance !=this) 
        {
            Destroy(this);
        }
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Show(string message, Vector2 position)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        tooltipText.text = message;
        backgroundRect.sizeDelta = tooltipText.GetPreferredValues(message) + new Vector2(16, 8);
        transform.position = position;
    }

    public void Hide()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
