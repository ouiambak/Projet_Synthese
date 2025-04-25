using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI waveText;
    public Slider playerHealthBar;
    public Button[] purchaseButtons;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// Met � jour le texte des pi�ces du joueur.
    /// </summary>
    public void UpdateCoinDisplay(int coins)
    {
        coinText.text = coins.ToString() + " $";
    }

    /// <summary>
    /// Met � jour le num�ro de la vague actuelle.
    /// </summary>
    public void UpdateWaveDisplay(int wave)
    {
        waveText.text = "Vague " + wave;
    }

    /// <summary>
    /// Met � jour la barre de vie du joueur.
    /// </summary>
    public void UpdateHealthBar(float vieActuelle, float vieMax)
    {
        playerHealthBar.value = vieActuelle / vieMax;
    }

    /// <summary>
    /// Active ou d�sactive les boutons selon si le joueur peut payer.
    /// </summary>
    public void SetButtonsInteractable(bool canAfford)
    {
        foreach (Button btn in purchaseButtons)
        {
            btn.interactable = canAfford;
        }
    }
}
