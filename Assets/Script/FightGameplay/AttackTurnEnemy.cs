using Unity.VisualScripting;
using UnityEngine;

public class AttackTurnEnemy : MonoBehaviour
{
    public delegate void OnTurnFinishedEnemy();
    public static event OnTurnFinishedEnemy turnFinishedEnemy;
    public float attackDamage;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AttackTo()
    {
        PlayerAlliesAutoReference plyRef = FightManager.Instance.partyMembers[Random.Range(1, FightManager.Instance.partyMembers.Count)].GetComponent<PlayerAlliesAutoReference>();
        plyRef.stats.statsLocal.PlayerCurrentHealth -= attackDamage - plyRef.stats.statsLocal.PlayerCurrentDefensa;
        anim.SetTrigger("AttackEn");
        Debug.Log("El enemigo " + gameObject.name + " ataca a " + plyRef.gameObject.name + " con " + attackDamage + " de daño.");
        //turnFinishedEnemy?.Invoke();
    }
    public void FinishTurnEnemy()
    {
        turnFinishedEnemy?.Invoke();
    }
}
