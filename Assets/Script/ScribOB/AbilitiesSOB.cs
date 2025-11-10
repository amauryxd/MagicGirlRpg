using UnityEngine;
[CreateAssetMenu(fileName = "NewAbility", menuName = "Scriptable Objects/NewAbility")]
public class AbilitiesSOB : ScriptableObject
{
    public string abilityName;
    public string abilityDesc;
    public float abilityAttack;
    public float abilityCost;
    public float abilityDrive;
    public AttackType abilityType;

}

