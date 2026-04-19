using UnityEngine;

public class ResetSobs : MonoBehaviour
{
    [SerializeField] PlayerStatsSOB[] allPlayerToReset;
    void Awake()
    {
        for(int index = 0; index < allPlayerToReset.Length; index++)
        {
            allPlayerToReset[index].playerCurrentHealth = allPlayerToReset[index].playerMaxHealth;
            allPlayerToReset[index].playerCurrentMana = allPlayerToReset[index].playerMaxMana;
            allPlayerToReset[index].playerCurrentAtaque = allPlayerToReset[index].playerAtaqueBase;
            allPlayerToReset[index].playerCurrentDefensa = allPlayerToReset[index].playerDefensaBase;
            allPlayerToReset[index].playerDrive = 0;
        }
    }
}
