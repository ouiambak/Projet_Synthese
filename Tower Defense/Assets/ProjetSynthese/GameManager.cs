using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerCoins = 100;

    void Awake()
    {
        Instance = this;
    }

    public bool HasEnoughCoins(int amount)
    {
        return playerCoins >= amount;
    }

    public void SpendCoins(int amount)
    {
        playerCoins -= amount;
        UIManager.Instance.UpdateCoinDisplay(playerCoins);
    }
}
