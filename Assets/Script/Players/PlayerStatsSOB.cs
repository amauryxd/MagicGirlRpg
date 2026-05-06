using UnityEngine;
[CreateAssetMenu(fileName = "NewStats", menuName = "Scriptable Objects/NewStats")]
public class PlayerStatsSOB : ScriptableObject
{
    public int playerLvl;
    public float playerMaxHealth;
    public float playerCurrentHealth;
    public float playerMaxMana;
    public float playerCurrentMana;
    public float playerAtaqueBase;
    public float playerCurrentAtaque;
    public float playerDefensaBase;
    public float playerCurrentDefensa;
    public float playerDrive;
    public string plyName;
    public Sprite plyImage;

}
