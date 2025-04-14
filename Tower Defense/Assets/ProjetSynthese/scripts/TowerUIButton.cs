using UnityEngine;

public class TowerUIButton : MonoBehaviour
{
    public GameObject towerPrefab; 

    public void OnClick()
    {
        BuildManager.Instance.StartPlacingTower(towerPrefab);
    }
}
