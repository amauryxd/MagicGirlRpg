using System;
using System.Collections.Generic;
using UnityEngine;

public class NozomiTurn : MonoBehaviour
{
    public List<AttackType> attacksReceived = new List<AttackType>();
    public Animator anim;
    private int tempid = 0;
    public delegate void OnAttackAnimFinishedNozomi(int id);
    public static event OnAttackAnimFinishedNozomi nozomiFinishedAttackAnim;
    void OnEnable()
    {
        TurnLogic.typeToNozomi += HandleTurnType;
    }
    void OnDisable()
    {
        TurnLogic.typeToNozomi -= HandleTurnType;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void HandleTurnType(AttackType type)
    {
        attacksReceived.Add(type);
    }
    public ResultEmotion CastToCast()
    {
        AttackType type1 = (attacksReceived.Count > 0) ? attacksReceived[0] : AttackType.None;
        AttackType type2 = (attacksReceived.Count > 1) ? attacksReceived[1] : AttackType.None;
        AttackType type3 = (attacksReceived.Count > 2) ? attacksReceived[2] : AttackType.None;

        if (type1 == AttackType.Enojo && type2 == AttackType.None) return ResultEmotion.Enojo;
        if (type1 == AttackType.Enojo && type2 == AttackType.Miedo) return ResultEmotion.DesesperacionAgresiva;
        if (type1 == AttackType.Tristesa && type2 == AttackType.None) return ResultEmotion.Tristesa;
        if (type1 == AttackType.Enojo && type2 == AttackType.Tristesa) return ResultEmotion.ExplocionEmocional;
        if (type1 == AttackType.Miedo && type2 == AttackType.None) return ResultEmotion.Miedo;
        if (type1 == AttackType.Miedo && type2 == AttackType.Tristesa) return ResultEmotion.Vulnerabilidad;
        return ResultEmotion.Esperanza;
    }
    public void DoTheAbilities()
    {
        ResultEmotion nozomiEmotion = CastToCast();
        Debug.Log("Nozomi attacara con la emocion: " + nozomiEmotion);
        switch (nozomiEmotion)
        {
            case ResultEmotion.Enojo:
                //ataca a 1 enemigo al azar
                tempid = UnityEngine.Random.Range(0, FightManager.Instance.enemies.Count);
                FightManager.Instance.enemies[tempid].OnHitOrDamage(15);
                textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> golpeando a "+FightManager.Instance.enemies[tempid].name;
                anim.SetTrigger("Do");
                break;
            case ResultEmotion.DesesperacionAgresiva:
                //ataca a todos los enemigos
                for (int indexAttack = 0; indexAttack < FightManager.Instance.enemies.Count; indexAttack++)
                    {
                        if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[indexAttack] != null)
                        FightManager.Instance.enemies[indexAttack].OnHitOrDamage(15);
                    }
                    Debug.Log("Ataco");
                    textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> atacando a todos los enemigos";
                    tempid = 99;
                anim.SetTrigger("Do");
                break;
            case ResultEmotion.Tristesa:
                //cura a 1 aliado
                tempid = UnityEngine.Random.Range(1, FightManager.Instance.partyMembers.Count);
                ApplyStatToModifNozomi(tempid, StatType.Vida, 8);
                textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> curando a un aliado";
                anim.SetTrigger("Do");
                break;
            case ResultEmotion.ExplocionEmocional:
                //cura a todas y hace dano a todo
                ApplyStatToModifNozomi(1, StatType.Vida, 5);
                ApplyStatToModifNozomi(2, StatType.Vida, 5);
                ApplyStatToModifNozomi(3, StatType.Vida, 5);
                for (int indexAttack = 0; indexAttack < FightManager.Instance.enemies.Count; indexAttack++)
                    {
                        if(FightManager.Instance.enemies.Count > 0 && FightManager.Instance.enemies[indexAttack] != null)
                        FightManager.Instance.enemies[indexAttack].OnHitOrDamage(15);
                    }
                    textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> curando aliados y atacando enemigos";
                    tempid = 99;
                anim.SetTrigger("Do");
                break;
            case ResultEmotion.Miedo:
                //sube 1 defenza al azar
                tempid = UnityEngine.Random.Range(1, FightManager.Instance.partyMembers.Count);
                ApplyStatToModifNozomi(tempid, StatType.Defensa, 8);
                textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> subiendo al defensa a un aliado";
                anim.SetTrigger("Do");
                break;
            case ResultEmotion.Vulnerabilidad:
                //sube el ataque de todas, baja la defenza de todas
                ApplyStatToModifNozomi(1, StatType.Ataque, 2);
                ApplyStatToModifNozomi(1, StatType.Defensa, -1f);
                ApplyStatToModifNozomi(2, StatType.Ataque, 2);
                ApplyStatToModifNozomi(2, StatType.Defensa, -1f);
                ApplyStatToModifNozomi(3, StatType.Ataque, 2);
                ApplyStatToModifNozomi(3, StatType.Defensa, -1f);
                textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> bajando la defensa pero subiendo el ataque a todas";
                anim.SetTrigger("Do");
                break;
            case ResultEmotion.Esperanza:
                //el caso default, cura a todo
                ApplyStatToModifNozomi(1, StatType.Vida, 5);
                ApplyStatToModifNozomi(2, StatType.Vida, 5);
                ApplyStatToModifNozomi(3, StatType.Vida, 5);
                textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa <color=#FF87F5>"+ nozomiEmotion+"</color> curando a todas";
                anim.SetTrigger("Do");
                break;
            default:
                //no deberiamos llegar aqui
                break;
        }
        //textoStatico.textoGlobal = "<color=#FF87F5>Nozomi</color> usa su habilidad <color=#FF87F5>"+ nozomiEmotion;
        //
        //attacksReceived.Clear();
    }
    public void doThing()
    {
        FightManager.Instance.turnActual = FightManager.ActualTurn.CheckWinnerPlayer;
        FightManager.Instance.nozomiOnce = true;
    }
    public void doDamageNozomi()
    {
        nozomiFinishedAttackAnim?.Invoke(tempid);
    }
    void ApplyStatToModifNozomi(int id, StatType statType,float cuantity)
    {
        switch (statType)
        {
            case StatType.Vida:
                FightManager.Instance.partyMembers[id].stats.statsBase.playerCurrentHealth += cuantity;
                break;
            case StatType.Mana:
                FightManager.Instance.partyMembers[id].stats.statsBase.playerCurrentMana += cuantity;
                break;
            case StatType.Ataque:
                FightManager.Instance.partyMembers[id].stats.statsBase.playerCurrentAtaque += cuantity;
                break;
            case StatType.Defensa:
                FightManager.Instance.partyMembers[id].stats.statsBase.playerCurrentDefensa += cuantity;
                break;
            case StatType.Drive:
                FightManager.Instance.partyMembers[id].stats.statsBase.playerDrive += cuantity;
                break;
            default:
                break;
        }
    }
}
