using System;
using System.Collections.Generic;
using UnityEngine;

public class TurnLogic : MonoBehaviour
{
    public enum TurnType { Attack, Defense, AllAttack, Escape, StatModif }
    public TurnType Type;
    public int id;
    [SerializeField] private AbilitesReference abilities;
    private PlayerStatsSOB stats;
    public delegate void OnTurnFinished();
    public static event OnTurnFinished turnFinished;
    public delegate void OnTurnTypeNozomi(AttackType type);
    public static event OnTurnTypeNozomi typeToNozomi;
    public Animator anim;
    public GameObject trailPrefab;
    public List<GameObject> armas;
    //public  player health
    void OnEnable()
    {
        EnemyHealth.enemyDeath += ArmaDeathEnemyID;
    }
    void OnDisable()
    {
        EnemyHealth.enemyDeath -= ArmaDeathEnemyID;
    }
    void ArmaDeathEnemyID(int id)
    {
        armas.RemoveAt(id);
    }
    void Start()
    {
        abilities = GetComponent<AbilitesReference>();
        stats = GetComponent<PlayerAlliesAutoReference>().stats.statsBase;
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
        //if(FightManager.Instance.enemies[id] == null) return;
        //conseguir el enemigo a atacar
        //restar la vida del enemigo
        if(!(FightManager.Instance.enemies.Count > 0 && id < FightManager.Instance.enemies.Count))
            id = UnityEngine.Random.Range(0, FightManager.Instance.enemies.Count);

        FightManager.Instance.enemies[id].OnHitOrDamage(abilities.firstAbility.abilityAttack+ stats.playerCurrentAtaque);
        textoStatico.textoGlobal = "<color="+getCharacterColor(gameObject.name)+">"+gameObject.name + "</color> ataca a <color=red>" + FightManager.Instance.enemies[id].gameObject.name+"</color>";
        /*Instantiate(trailPrefab, transform.position, Quaternion.identity).GetComponent<HitEffectFollower>().setPoints(transform, FightManager.Instance.enemies[id].transform, 1f);*/
        //bajar mana
        //stats.playerCurrentMana -= abilities.firstAbility.abilityCost;
        //subir drive
        stats.playerDrive += abilities.firstAbility.abilityDrive;
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
        //99 significa que ataca a todos
        id = 99;
        textoStatico.textoGlobal = "<color="+getCharacterColor(gameObject.name)+">"+gameObject.name + "</color> ataca a todos los enemigos!";
        for (int indexAttack = 0; indexAttack < FightManager.Instance.enemies.Count; indexAttack++)
        {
            if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[indexAttack] != null)
            FightManager.Instance.enemies[indexAttack].OnHitOrDamage(abilities.secondAbility.abilityAttack+ stats.playerCurrentAtaque);
        }
        //stats.PlayerCurrentMana -= abilities.secondAbility.abilityCost;
        stats.playerDrive += abilities.secondAbility.abilityDrive;
        typeToNozomi?.Invoke(abilities.secondAbility.abilityType);
        anim.SetTrigger("Do");
        //turnFinished?.Invoke();
    }
    public void OnDefenseTurn()
    {
        Debug.Log("Defendiendo");
        textoStatico.textoGlobal = "<color="+getCharacterColor(gameObject.name)+">"+gameObject.name + "</color> se defiende!";
        stats.playerCurrentDefensa += stats.playerLvl *0.5f;
        anim.SetTrigger("Defence");
        //turnFinished?.Invoke();
        //stats.PlayerCurrentDefensa -= stats.PlayerLvl *0.5f;
        //aumentar las estadisticas del personaje
        //observar a cuando termine el turno enemigo
    }
    public void OnStatModif()
    {
        Debug.Log("modificando "+ abilities.statAbility.abilityType +" en "+ abilities.statAbility.abilityStatModif);
        textoStatico.textoGlobal = "<color="+getCharacterColor(gameObject.name)+">"+gameObject.name + "</color> modifica su " + abilities.statAbility.abilityType + " a " + "<color="+getCharacterColor(FightManager.Instance.partyMembers[id+1].gameObject.name)+">"+FightManager.Instance.partyMembers[id+1].gameObject.name+"</color>";
        ApplyStatToModif(id, abilities.statAbility.abilityType);
        stats.playerCurrentMana -= abilities.statAbility.abilityCost;
        stats.playerDrive += abilities.statAbility.abilityDrive;
        anim.SetTrigger("StatModif");
        //turnFinished?.Invoke();
    }
    private void OnEscapeTurn()
    {
        Debug.Log("Escapa");
        anim.SetTrigger("Do");
        //turnFinished?.Invoke();
        //lanzar el evento de intento de escape
    }
    public string getCharacterColor(string whoName)
    {
        switch (whoName)
        {
            case "Hinoka":
                return "red";
            case "Yami":
                return "orange";
            case "Sayo":
                return "blue";
            default:
                return "white";
        }
    }
    void ApplyStatToModif(int id, StatType statType)
    {
        switch (statType)
        {
            case StatType.Vida:
                FightManager.Instance.partyMembers[id+1].stats.statsBase.playerCurrentHealth += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Mana:
                FightManager.Instance.partyMembers[id+1].stats.statsBase.playerCurrentMana += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Ataque:
                FightManager.Instance.partyMembers[id+1].stats.statsBase.playerCurrentAtaque += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Defensa:
                FightManager.Instance.partyMembers[id+1].stats.statsBase.playerCurrentDefensa += abilities.statAbility.abilityStatModif;
                break;
            case StatType.Drive:
                FightManager.Instance.partyMembers[id+1].stats.statsBase.playerDrive += abilities.statAbility.abilityStatModif;
                break;
            default:
                break;
        }
    }
    public void ActivarArma()
    {
        if(id != 99){
        armas[id].SetActive(true);
        }
        else
        {
            foreach(GameObject arma in armas)
            {
                arma.SetActive(true);
            }
            /*for(int i = 0; i < FightManager.Instance.enemies.Count; i++)
            {
                if(FightManager.Instance.enemies[i].gameObject.activeInHierarchy)
                {
                    armas[i].SetActive(true);
                }
            }*/
        }
    }
    public void DesactivarArma()
    {
        if(id != 99){
        armas[id].SetActive(false);
        }
        else
        {
            foreach(GameObject arma in armas)
            {
                arma.SetActive(false);
            }
        }
    }
}
