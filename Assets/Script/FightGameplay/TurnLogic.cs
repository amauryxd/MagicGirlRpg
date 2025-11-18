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
    //public  player health
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        abilities = GetComponent<AbilitesReference>();
        stats = GetComponent<PlayerAlliesAutoReference>().stats.statsLocal;
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
    public void OnAttackTurn()
    {
        Debug.Log("Atacando al enemigo con id " + id);
        //conseguir el enemigo a atacar
        //restar la vida del enemigo
        if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[id] != null)
        FightManager.Instance.enemies[id].OnHitOrDamage(abilities.firstAbility.abilityAttack+ stats.PlayerCurrentAtaque);
        //bajar mana
        stats.PlayerCurrentMana -= abilities.firstAbility.abilityCost;
        //subir drive
        stats.PlayerDrive += abilities.firstAbility.abilityDrive;
        //mandara a nozomi q hacer
        typeToNozomi?.Invoke(abilities.firstAbility.abilityType);
        //lamar las animaciones del ataque
        //mandar el evento de turno terminado
        turnFinished?.Invoke();
    }
    public void OnAllAttackTurn()
    {
        Debug.Log("Atacando a los enemigos");
        for (int indexAttack = 0; indexAttack < FightManager.Instance.enemies.Count; indexAttack++)
        {
            if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[indexAttack] != null)
            FightManager.Instance.enemies[indexAttack].OnHitOrDamage(abilities.secondAbility.abilityAttack+ stats.PlayerCurrentAtaque);
        }
        stats.PlayerCurrentMana -= abilities.secondAbility.abilityCost;
        stats.PlayerDrive += abilities.secondAbility.abilityDrive;
        typeToNozomi?.Invoke(abilities.secondAbility.abilityType);
        turnFinished?.Invoke();
    }
    public void OnDefenseTurn()
    {
        Debug.Log("Defendiendo");
        stats.PlayerCurrentDefensa += stats.PlayerLvl *0.5f;
        turnFinished?.Invoke();
        stats.PlayerCurrentDefensa -= stats.PlayerLvl *0.5f;
        //aumentar las estadisticas del personaje
        //observar a cuando termine el turno enemigo
    }
    public void OnStatModif()
    {
        Debug.Log("modificando "+ abilities.statAbility.abilityType +" en "+ abilities.statAbility.abilityStatModif);
        ApplyStatToModif(id, abilities.statAbility.abilityType);
        stats.PlayerCurrentMana -= abilities.statAbility.abilityCost;
        stats.PlayerDrive += abilities.statAbility.abilityDrive;
        turnFinished?.Invoke();
    }
    private void OnEscapeTurn()
    {
        Debug.Log("Escapa");
        turnFinished?.Invoke();
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
