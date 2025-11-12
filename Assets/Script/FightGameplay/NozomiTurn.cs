using System;
using System.Collections.Generic;
using UnityEngine;

public class NozomiTurn : MonoBehaviour
{
    public List<AttackType> attacksReceived = new List<AttackType>();
    void OnEnable()
    {
        TurnLogic.typeToNozomi += HandleTurnType;
    }
    void OnDisable()
    {
        TurnLogic.typeToNozomi -= HandleTurnType;
    }
    void HandleTurnType(AttackType type)
    {
        attacksReceived.Add(type);
        Debug.Log("Nozomi received an attack of type: " + type);
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
        if (type1 == AttackType.Tristesa && type2 == AttackType.Miedo) return ResultEmotion.Vulnerabilidad;
        return ResultEmotion.None;
    }
    public void DoTheAbilities()
    {
        Debug.Log("Nozomi attacara con la emocion: " + CastToCast());
        attacksReceived.Clear();
    }
}
