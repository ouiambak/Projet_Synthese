using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent<int> OnCoinsChanged = new UnityEvent<int>();
    public int playerCoins = 100;

    void Awake()
    {
        Instance = this;
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

}
