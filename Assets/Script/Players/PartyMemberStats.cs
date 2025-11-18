using UnityEngine;

public class PartyMemberStats : MonoBehaviour
{
    public PlayerStatsSOB statsBase;
    public PlayerStatsLocal statsLocal = new PlayerStatsLocal();
    void Awake()
    {
        statsLocal.PlayerLvl = statsBase.playerLvl;
        statsLocal.PlayerMaxHealth = statsBase.playerHealth;
        statsLocal.PlayerMaxMana = statsBase.playerMana;
        statsLocal.PlayerAtaque = statsBase.playerAtaque;
        statsLocal.PlayerDefensa = statsBase.playerDefensa;
        statsLocal.PlayerDrive = statsBase.playerDrive;
    }
    void Start()
    {
        statsLocal.PlayerCurrentHealth = statsLocal.PlayerMaxHealth;
        statsLocal.PlayerCurrentMana = statsLocal.PlayerMaxMana;
        statsLocal.PlayerCurrentAtaque = statsLocal.PlayerAtaque;
        statsLocal.PlayerCurrentDefensa = statsLocal.PlayerDefensa;
    }


}
[System.Serializable]
public class PlayerStatsLocal
{
    public int PlayerLvl;
    public float PlayerMaxHealth;
    public float PlayerCurrentHealth;
    public float PlayerMaxMana;
    public float PlayerCurrentMana;
    public float PlayerAtaque;
    public float PlayerCurrentAtaque;
    public float PlayerDefensa;
    public float PlayerCurrentDefensa;
    public float PlayerDrive;
}