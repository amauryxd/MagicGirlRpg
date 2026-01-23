using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(changeSceneAfter());
    }

    public IEnumerator changeSceneAfter()
    {
        yield return new WaitForSeconds(25);
        SceneManager.LoadScene("Menu");
    }
}
