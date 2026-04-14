using UnityEngine;
using UnityEngine.SceneManagement;

public class onEnemyActivateBattle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene("GameplayTest");
        }
    }
}
