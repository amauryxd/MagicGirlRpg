using UnityEngine;
using UnityEngine.SceneManagement;

public class onEnemyActivateBattle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if(other.tag == "Player")
        {
            //animacion de entrar a combate
            SceneManager.LoadScene("GameplayTest");
        }
    }
}
