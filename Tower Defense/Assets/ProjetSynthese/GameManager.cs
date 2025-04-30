using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UnityEvent<int> OnCoinsChanged = new UnityEvent<int>();
    public int playerCoins = 100;

    [Header("Vie du joueur")]
    public int vieMax = 5;
    public int vieActuelle = 5;

    [SerializeField] private Slider sliderVie;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        MettreAJourSlider();
    }

    public bool HasEnoughCoins(int amount)
    {
        return playerCoins >= amount;
    }

    public void GagnerRessources(int montant)
    {
        playerCoins += montant;
        UIManager.Instance.UpdateCoinDisplay(playerCoins);
        OnCoinsChanged.Invoke(playerCoins);
    }

    public void SpendCoins(int amount)
    {
        playerCoins -= amount;
        UIManager.Instance.UpdateCoinDisplay(playerCoins);
        OnCoinsChanged.Invoke(playerCoins);
    }

    public void PerdreVie()
    {
        vieActuelle--;
        MettreAJourSlider();

        Debug.Log($" Vie restante : {vieActuelle}/{vieMax}");

        if (vieActuelle <= 0)
        {
            GameOver();
        }
    }

    private void MettreAJourSlider()
    {
        if (sliderVie != null)
        {
            sliderVie.maxValue = vieMax;
            sliderVie.value = vieActuelle;
        }
    }

    private void GameOver()
    {
        Debug.Log(" GAME OVER !");
        SceneManager.LoadScene("GameOver");
    }
}
