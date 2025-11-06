using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    private float actualHealth;
    private void Start()
    {
        actualHealth = enemyHealth;
    }
    public void OnHitOrDamage(float cuantity)
    {
        actualHealth -= cuantity;
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
            Debug.Log("El enemigo se murio :c");
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        FightManager.Instance.enemies.Add(this);
    }
    void OnDisable()
    {
        FightManager.Instance.enemies.Remove(this);
    }
}
