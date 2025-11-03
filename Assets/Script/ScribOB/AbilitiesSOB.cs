using UnityEngine;
[CreateAssetMenu(fileName = "NewAbility", menuName = "Scriptable Objects/NewAbility")]
public class AbilitiesSOB : ScriptableObject
{
    public string abilityName;
    public int abilityType;
    public string abilityDesc;
    public int abilityCost;
    public int abilityCharge;
}
