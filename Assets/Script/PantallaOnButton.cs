using UnityEngine;

public class PantallaOnButton : MonoBehaviour
{
    public void ChangeSceneTo(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
