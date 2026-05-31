using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    private float actualHealth;
    public Slider healthBar;
    public GameObject tempPrefab;
    public bool canGetHit = false;
    public int idLocal;
    public delegate void OnEnemyDeath(int id);
    public static event OnEnemyDeath enemyDeath;
    public bool isBossHealth;
    public bool isBossHand;
    public BossBehaviour bossVariables;
    public Animator anim;
    void OnEnable()
    {
        RotacionSelect.attackAnimFinished += getHitAnim;
        NozomiTurn.nozomiFinishedAttackAnim += getHitAnim;
    }
    void OnDisable()
    {
        RotacionSelect.attackAnimFinished -= getHitAnim;
        NozomiTurn.nozomiFinishedAttackAnim -= getHitAnim;
        enemyDeath?.Invoke(idLocal);
        FightManager.Instance.enemies.Remove(this);
    }
    private void getHitAnim(int id)
    {
        if(!isBossHealth || isBossHand){
            if(FightManager.Instance.enemies.IndexOf(this) == id)
            {
                canGetHit = true;
            }
            if(id == 99)
            {
                canGetHit = true;
            }
            return;
        }
        if(isBossHealth && bossVariables.CheckHandDestroyed())
        {
            if(FightManager.Instance.enemies.IndexOf(this) == id)
            {
                canGetHit = true;
            }
            if(id == 99)
            {
                canGetHit = true;
            }
        }
        else
        {
            anim.SetTrigger("NullDamage");
        }
    }
    private void Start()
    {
        canGetHit = false;
        FightManager.Instance.enemies.Add(this);
        actualHealth = enemyHealth;
        healthBar.value = actualHealth;
        //bossVariables = GetComponent<BossBehaviour>();
    }
    public void OnHitOrDamage(float cuantity)
    {
        StartCoroutine(waitForHitEffect(cuantity));
    }
    private IEnumerator waitForHitEffect(float cuantity)
    {
        yield return new WaitUntil(() => canGetHit);
        actualHealth -= cuantity;
        healthBar.value = actualHealth;
        canGetHit = false;
        IsDeadEnemy();
    }
    public void OnHealOrRevival(float cuantity)
    {
        actualHealth += cuantity;
    }

    public void IsDeadEnemy()
    {
        if (actualHealth <= 0)
        {
            if(isBossHealth)
            {
                anim.SetTrigger("DeathBoss");
                FightManager.Instance.enemies.Remove(this);
                FightManager.Instance.StopAllCoroutines();
                return;
            }
            if (isBossHand)
            {
                bossVariables.handsDestroyed++;
            }
            Instantiate(tempPrefab,transform.position, Quaternion.identity);
            Debug.Log("El enemigo se murio :c");
            gameObject.SetActive(false);
        }
    }
    
}
