using UnityEngine;

[CreateAssetMenu(fileName = "NewStatAbility", menuName = "Scriptable Objects/NewStatAbility")]
public class AbilitesStatSOb : ScriptableObject
{
    public string abilityName;
    public string abilityDesc;
    public float abilityStatModif;
    public float abilityCost;
    public float abilityDrive;
    public StatType abilityType;
}
