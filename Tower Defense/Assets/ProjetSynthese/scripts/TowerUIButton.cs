using UnityEngine;

public class TowerUIButton : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 75; // 💰 Le coût de cette tour spécifique

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
}
