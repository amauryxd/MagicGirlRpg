using System.Collections;
using UnityEngine;

public class AttackTurnEnemy : MonoBehaviour
{
    public delegate void OnTurnFinishedEnemy();
    public static event OnTurnFinishedEnemy turnFinishedEnemy;
    public float attackDamage;
    private Animator anim;
    PlayerAlliesAutoReference plyRef;
    [Header("Boss Variables")]
    public bool isBoss = false;
    public EnemyHealth healthForBoss;
    public bool canAttackBoss = false;
    public bool isBossHand;
    public ParticleSystem cargar;
    public PlayerAlliesAutoReference HinokaRef;
    public PlayerAlliesAutoReference YamiRef;
    public PlayerAlliesAutoReference SayoRef;


    private void Start()
    {
        anim = GetComponent<Animator>();
        healthForBoss = GetComponent<EnemyHealth>();
        if(isBoss){
            canAttackBoss = false;
        }
    }
    public void AttackTo()
    {
        if(!isBoss || isBossHand){
            plyRef = FightManager.Instance.partyMembers[Random.Range(1, FightManager.Instance.partyMembers.Count)].GetComponent<PlayerAlliesAutoReference>();
            plyRef.stats.statsBase.playerCurrentHealth -= attackDamage - plyRef.stats.statsBase.playerCurrentDefensa;
            anim.SetTrigger("AttackEn");
            //StartCoroutine(activarAttaque(plyRef));
            //Debug.Log("El enemigo " + gameObject.name + " ataca a " + plyRef.gameObject.name + " con " + attackDamage + " de daño.");
            textoStatico.textoGlobal = "<color=red>"+gameObject.name + "</color> ataca a <color=blue>" + plyRef.gameObject.name + "</color> con " + (attackDamage - plyRef.stats.statsBase.playerCurrentDefensa) + " de daño.";
            healthForBoss.canGetHit = false;
            //turnFinishedEnemy?.Invoke(); 
            //turnFinishedEnemy?.Invoke();
        }
        if (isBoss)
        {
            if (!NextPhaseBoss())
            {
                if (canAttackBoss)
                {
                    cargar.Stop();
                    HinokaRef.stats.statsBase.playerCurrentHealth -= attackDamage - HinokaRef.stats.statsBase.playerCurrentDefensa;
                    YamiRef.stats.statsBase.playerCurrentHealth -= attackDamage - YamiRef.stats.statsBase.playerCurrentDefensa;
                    SayoRef.stats.statsBase.playerCurrentHealth -= attackDamage - SayoRef.stats.statsBase.playerCurrentDefensa;
                    anim.SetTrigger("AttackPhase2");
                    textoStatico.textoGlobal = "<color=red>" + gameObject.name + "</color> ataca a todas";
                    healthForBoss.canGetHit = false;
                    canAttackBoss = false;
                }
                else
                {
                    //anim.SetTrigger("Preparar");
                    cargar.Play();
                    StartCoroutine(FinishMovement());
                    textoStatico.textoGlobal = "<color=red>"+gameObject.name + "</color> esta preparando su ataque";
                    healthForBoss.canGetHit = false;
                    canAttackBoss = true;
                }
            }
            else
            {
                cargar.Stop();
                HinokaRef.stats.statsBase.playerCurrentHealth -= attackDamage - HinokaRef.stats.statsBase.playerCurrentDefensa;
                YamiRef.stats.statsBase.playerCurrentHealth -= attackDamage - YamiRef.stats.statsBase.playerCurrentDefensa;
                SayoRef.stats.statsBase.playerCurrentHealth -= attackDamage - SayoRef.stats.statsBase.playerCurrentDefensa;
                anim.SetTrigger("AttackPhase2");
                textoStatico.textoGlobal = "<color=red>" + gameObject.name + "</color> ataca a todas";
                healthForBoss.canGetHit = false;
            }
        }
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
    public void SetAttackHitAnimHands()
    {
        plyRef.plyHealth.value = plyRef.stats.statsBase.playerCurrentHealth;
        CameraShaker.Instance.ShakeThisCamera(0.2f, 0.03f);
    }
    #region BossComands
    public bool NextPhaseBoss()
    {
        if(healthForBoss.enemyHealth <= healthForBoss.enemyHealth/2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void BossAttackHitAnimPhase1()
    {
        HinokaRef.plyHealth.value = HinokaRef.stats.statsBase.playerCurrentHealth;
        YamiRef.plyHealth.value = YamiRef.stats.statsBase.playerCurrentHealth;
        SayoRef.plyHealth.value = SayoRef.stats.statsBase.playerCurrentHealth;
        CameraShaker.Instance.ShakeThisCamera(0.2f, 0.05f);
    }
    public void BossAttackHitAnimPhase2()
    {
        HinokaRef.plyHealth.value = HinokaRef.stats.statsBase.playerCurrentHealth;
        YamiRef.plyHealth.value = YamiRef.stats.statsBase.playerCurrentHealth;
        SayoRef.plyHealth.value = SayoRef.stats.statsBase.playerCurrentHealth;
        CameraShaker.Instance.ShakeThisCamera(2f, 0.8f);
    }
    public IEnumerator FinishMovement()
    {
        yield return new WaitForSeconds(3);
        FinishTurnEnemy();
    }

    #endregion
}
