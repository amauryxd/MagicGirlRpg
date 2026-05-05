using UnityEngine;
using UnityEngine.SceneManagement;

public class onEnemyActivateBattle : MonoBehaviour
{
    public int localIndex;
    public EnemysSOBActivate enemySob;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if(other.tag == "Player")
        {
            //animacion de entrar a combate
            enemySob.wichEnemyNow = localIndex;
            SceneManager.LoadScene("GameplayTest");
        }
    }
}
