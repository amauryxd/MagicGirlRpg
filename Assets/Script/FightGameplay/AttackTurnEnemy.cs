using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AttackTurnEnemy : MonoBehaviour
{
    public delegate void OnTurnFinishedEnemy();
    public static event OnTurnFinishedEnemy turnFinishedEnemy;
    public float attackDamage;
    private Animator anim;
    PlayerAlliesAutoReference plyRef;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AttackTo()
    {
        plyRef = FightManager.Instance.partyMembers[Random.Range(1, FightManager.Instance.partyMembers.Count)].GetComponent<PlayerAlliesAutoReference>();
        plyRef.stats.statsBase.playerCurrentHealth -= attackDamage - plyRef.stats.statsBase.playerCurrentDefensa;
        anim.SetTrigger("AttackEn");
        //StartCoroutine(activarAttaque(plyRef));
        Debug.Log("El enemigo " + gameObject.name + " ataca a " + plyRef.gameObject.name + " con " + attackDamage + " de daño.");
        textoStatico.textoGlobal = "<color=red>"+gameObject.name + "</color> ataca a <color=blue>" + plyRef.gameObject.name + "</color> con " + (attackDamage - plyRef.stats.statsBase.playerCurrentDefensa) + " de daño.";
        GetComponent<EnemyHealth>().canGetHit = false;
         //turnFinishedEnemy?.Invoke(); 
        //turnFinishedEnemy?.Invoke();
    }
    public void FinishTurnEnemy()
    {
        turnFinishedEnemy?.Invoke();
        plyRef = null;
    }
    public void StartCorutineAttack()
    {
        StartCoroutine(activarAttaque(plyRef));
    }
    public IEnumerator activarAttaque(PlayerAlliesAutoReference plycosa)
    {
        plycosa.particles.Play();
        plycosa.plyHealth.value = plycosa.stats.statsBase.playerCurrentHealth;
        yield return new WaitForSeconds(2.5f);
        plycosa.particles.Stop();
    }
}
