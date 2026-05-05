using UnityEngine;

public class ResetSobs : MonoBehaviour
{
    [SerializeField] PlayerStatsSOB[] allPlayerToReset;
    public CheckPointsSOB checkPointsSOB;
    public EnemysSOBActivate enemysSOBActivate;
    void Awake()
    {
        for(int index = 0; index < allPlayerToReset.Length; index++)
        {
            allPlayerToReset[index].playerCurrentHealth = allPlayerToReset[index].playerMaxHealth;
            allPlayerToReset[index].playerCurrentMana = allPlayerToReset[index].playerMaxMana;
            allPlayerToReset[index].playerCurrentAtaque = allPlayerToReset[index].playerAtaqueBase;
            allPlayerToReset[index].playerCurrentDefensa = allPlayerToReset[index].playerDefensaBase;
            allPlayerToReset[index].playerDrive = 0;
            Debug.Log("Player " + allPlayerToReset[index].name + " reseted");
        }
        checkPointsSOB.checkPointIndex = 0;
        enemysSOBActivate.wichEnemyNow = 0;
        enemysSOBActivate.enemy1Active = true;
        enemysSOBActivate.enemy2Active = true;
        enemysSOBActivate.enemy3Active = true;
        enemysSOBActivate.enemy4Active = true;
    }
}
