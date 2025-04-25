using UnityEngine;
using UnityEngine.UI;

public class TowerUIButton : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 75;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnCoinsChanged.AddListener(CheckAffordability);
            CheckAffordability(GameManager.Instance.playerCoins);
        }
        else
        {
            Debug.LogWarning("GameManager.Instance est introuvable !");
        }
    }

    public void OnClick()
    {
        if (GameManager.Instance.HasEnoughCoins(towerCost))
        {
            GameManager.Instance.SpendCoins(towerCost);
            BuildManager.Instance.StartPlacingTower(towerPrefab);
        }
        else
        {
            Debug.Log("Pas assez de pièces pour construire cette tour !");
        }
    }

    private void CheckAffordability(int currentCoins)
    {
        if (_button != null)
        {
            _button.interactable = currentCoins >= towerCost;
        }
    }
}
