using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalDugeonNextScene : MonoBehaviour
{
    public void ChangeSceneBattle()
    {
        SceneManager.LoadScene("GameplayTest");
    }
}
