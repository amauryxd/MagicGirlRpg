using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneString : MonoBehaviour
{
    public void sceneToChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
