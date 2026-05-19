using UnityEngine;

public class ResetSobs : MonoBehaviour
{
    [SerializeField] PlayerStatsSOB[] allPlayerToReset;
    public EnemysSOBActivate enemysSOBActivate;
    void Awake()
    {
        ThingsToReset();
    }
    [ContextMenu("ResetThingsPls")]
    public void ThingsToReset()
    {
        for(int index = 0; index < allPlayerToReset.Length; index++)
        {
            allPlayerToReset[index].playerCurrentHealth = allPlayerToReset[index].playerMaxHealth;
            Debug.Log(allPlayerToReset[index].name +" reseteo: este dato a"+ allPlayerToReset[index].playerCurrentHealth);
            allPlayerToReset[index].playerCurrentMana = allPlayerToReset[index].playerMaxMana;
            Debug.Log(allPlayerToReset[index].name +" reseteo este dato a: "+ allPlayerToReset[index].playerCurrentMana);
            allPlayerToReset[index].playerCurrentAtaque = allPlayerToReset[index].playerAtaqueBase;
            Debug.Log(allPlayerToReset[index].name +" reseteo este dato a: "+ allPlayerToReset[index].playerCurrentAtaque);
            allPlayerToReset[index].playerCurrentDefensa = allPlayerToReset[index].playerDefensaBase;
            Debug.Log(allPlayerToReset[index].name +" reseteo este dato a: "+ allPlayerToReset[index].playerCurrentDefensa);
            allPlayerToReset[index].playerDrive = 0;
            Debug.Log(allPlayerToReset[index].name +" reseteo este dato a: "+ allPlayerToReset[index].playerDrive);
            Debug.Log("Player " + allPlayerToReset[index].name + " reseted");
        }
        enemysSOBActivate.wichEnemyNow = 0;
        enemysSOBActivate.enemy1Active = true;
        enemysSOBActivate.enemy2Active = true;
        enemysSOBActivate.enemy3Active = true;
        enemysSOBActivate.enemy4Active = true;
        HasBeenDungeon.hasBeen = false;
        CheckPointLoader.checkPointIndex = 0;
        DungeonManager.Door1 = true;
        DungeonManager.Door2 = true;
    }
}
