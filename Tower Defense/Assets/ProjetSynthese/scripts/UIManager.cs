using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateCoinDisplay(int coins)
    {
        coinText.text = coins.ToString() + "$";
    }
}
