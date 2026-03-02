using System;
using UnityEngine;

public class TurnLogic : MonoBehaviour
{
    public enum TurnType { Attack, Defense, AllAttack, Escape, StatModif }
    public TurnType Type;
    public int id;
    [SerializeField] private AbilitesReference abilities;
    private PlayerStatsLocal stats;
    public delegate void OnTurnFinished();
    public static event OnTurnFinished turnFinished;
    public delegate void OnTurnTypeNozomi(AttackType type);
    public static event OnTurnTypeNozomi typeToNozomi;
    public Animator anim;
    public GameObject trailPrefab;
    //public  player health
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        abilities = GetComponent<AbilitesReference>();
        stats = GetComponent<PlayerAlliesAutoReference>().stats.statsLocal;
        anim = GetComponent<Animator>();
    }
    public void MakeTurn()
    {
        switch (Type)
        {
            case TurnType.Attack:
                OnAttackTurn();
                break;
            case TurnType.Defense:
                OnDefenseTurn();
                break;
            case TurnType.AllAttack:
                OnAllAttackTurn();
                break;
            case TurnType.Escape:
                OnEscapeTurn();
                break;
            case TurnType.StatModif:
                OnStatModif();
                break;
            default:
                break;
        }
    }
    public void NextTurn()
    {
        //comprobar cuanto drive hay
        //animacion de drive cargado
        //las habilidades pasan a ser drive
        turnFinished?.Invoke();
    }
    public void OnAttackTurn()
    {
        Debug.Log("Atacando al enemigo con id " + id);
        if(FightManager.Instance.enemies[id] == null) return;
        textoStatico.textoGlobal = gameObject.name + " ataca a " + FightManager.Instance.enemies[id].gameObject.name;
        //conseguir el enemigo a atacar
        //restar la vida del enemigo
        if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[id] != null){
        FightManager.Instance.enemies[id].OnHitOrDamage(abilities.firstAbility.abilityAttack+ stats.PlayerCurrentAtaque);
        /*Instantiate(trailPrefab, transform.position, Quaternion.identity).GetComponent<HitEffectFollower>().setPoints(transform, FightManager.Instance.enemies[id].transform, 1f);*/
        }
        //bajar mana
        stats.PlayerCurrentMana -= abilities.firstAbility.abilityCost;
        //subir drive
        stats.PlayerDrive += abilities.firstAbility.abilityDrive;
        //mandara a nozomi q hacer
        typeToNozomi?.Invoke(abilities.firstAbility.abilityType);
        anim.SetTrigger("Do");
        //lamar las animaciones del ataque
        //mandar el evento de turno terminado
        //turnFinished?.Invoke();
        //shake
        //CameraShaker.Instance.ShakeThisCamera(0.1f,0.2f);
    }
    public void OnAllAttackTurn()
    {
        Debug.Log("Atacando a los enemigos");
        textoStatico.textoGlobal = gameObject.name + " ataca a todos los enemigos!";
        for (int indexAttack = 0; indexAttack < FightManager.Instance.enemies.Count; indexAttack++)
        {
            if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[indexAttack] != null)
            FightManager.Instance.enemies[indexAttack].OnHitOrDamage(abilities.secondAbility.abilityAttack+ stats.PlayerCurrentAtaque);
        }
        stats.PlayerCurrentMana -= abilities.secondAbility.abilityCost;
        stats.PlayerDrive += abilities.secondAbility.abilityDrive;
        typeToNozomi?.Invoke(abilities.secondAbility.abilityType);
        anim.SetTrigger("Do");
        //turnFinished?.Invoke();
    }
    public void OnDefenseTurn()
    {
        Debug.Log("Defendiendo");
        textoStatico.textoGlobal = gameObject.name + " se defiende!";
        stats.PlayerCurrentDefensa += stats.PlayerLvl *0.5f;
        anim.SetTrigger("Do");
        //turnFinished?.Invoke();
        //stats.PlayerCurrentDefensa -= stats.PlayerLvl *0.5f;
        //aumentar las estadisticas del personaje
        //observar a cuando termine el turno enemigo
    }
    public void OnStatModif()
    {
        Debug.Log("modificando "+ abilities.statAbility.abilityType +" en "+ abilities.statAbility.abilityStatModif);
        textoStatico.textoGlobal = gameObject.name + " modifica su " + abilities.statAbility.abilityType + " a " + FightManager.Instance.partyMembers[id+1].gameObject.name;
        ApplyStatToModif(id, abilities.statAbility.abilityType);
        stats.PlayerCurrentMana -= abilities.statAbility.abilityCost;
        stats.PlayerDrive += abilities.statAbility.abilityDrive;
        anim.SetTrigger("Do");
        //turnFinished?.Invoke();
    }
    private void OnEscapeTurn()
    {
        Debug.Log("Escapa");
        anim.SetTrigger("Do");
        //turnFinished?.Invoke();
        //lanzar el evento de intento de escape
    }
    void ApplyStatToModif(int id, StatType statType)
    {
        switch (statType)
        {
            case StatType.Vida:
                FightManager.Instance.partyMembers[id+1].stats.statsLocal.PlayerCurrentHealth += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Mana:
                FightManager.Instance.partyMembers[id+1].stats.statsLocal.PlayerCurrentMana += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Ataque:
                FightManager.Instance.partyMembers[id+1].stats.statsLocal.PlayerCurrentAtaque += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Defensa:
                FightManager.Instance.partyMembers[id+1].stats.statsLocal.PlayerCurrentDefensa += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Drive:
                FightManager.Instance.partyMembers[id+1].stats.statsLocal.PlayerDrive += abilities.statAbility.abilityStatModif;
                break;
            default:
                break;
        }
    }
}
