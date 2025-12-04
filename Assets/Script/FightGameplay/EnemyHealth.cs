using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    private float actualHealth;
    public Slider healthBar;
    public GameObject tempPrefab;
    private void Start()
    {
        FightManager.Instance.enemies.Add(this);
        actualHealth = enemyHealth;
        healthBar.value = actualHealth;
    }
    public void OnHitOrDamage(float cuantity)
    {
        actualHealth -= cuantity;
        healthBar.value = actualHealth;
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
    /*void OnEnable()
    {
        Debug.Log(FightManager.Instance);
        FightManager.Instance.enemies.Add(this);
    }*/
    void OnDisable()
    {
        FightManager.Instance.enemies.Remove(this);
    }
}
