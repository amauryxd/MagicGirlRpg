using System.Collections;
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
    void OnEnable()
    {
        RotacionSelect.attackAnimFinished += getHitAnim;
    }
    void OnDisable()
    {
        RotacionSelect.attackAnimFinished -= getHitAnim;
        FightManager.Instance.enemies.Remove(this);
    }
    private void getHitAnim(int id)
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
    private void Start()
    {
        canGetHit = false;
        FightManager.Instance.enemies.Add(this);
        actualHealth = enemyHealth;
        healthBar.value = actualHealth;
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
            Instantiate(tempPrefab,transform.position, Quaternion.identity);
            Debug.Log("El enemigo se murio :c");
            gameObject.SetActive(false);
        }
    }
    
}
