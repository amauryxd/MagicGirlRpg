using UnityEngine;
using UnityEngine.SceneManagement;

public class onEnemyActivateBattle : MonoBehaviour
{
    public int localIndex;
    public EnemysSOBActivate enemySob;
    public Animator enemyAnim;
    public Animator globalAnim;
    public EnemyBehaviour enem;
    void Start()
    {
        enem = GetComponent<EnemyBehaviour>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            //animacion de entrar a combate
            enemySob.wichEnemyNow = localIndex;
            DungeonManager.Instance.dungeonStates = DungeonStates.cinematic;
            enemyAnim.SetTrigger("Contact");
            globalAnim.SetTrigger("DoFight");
            enem.speed = 0;
            DungeonManager.playerLastPos = other.transform.position;
            
            //SceneManager.LoadScene("GameplayTest");
        }
    }
}
