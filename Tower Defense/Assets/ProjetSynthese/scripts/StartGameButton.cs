using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private string sceneName = "Tower Defense";

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene(sceneName);
    }
}
