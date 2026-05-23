using UnityEngine;

public class CHangeCheckPoint : MonoBehaviour
{
    public int localIndex;
    public PlayerStatsSOB hinokastats;
    public PlayerStatsSOB yamistats;
    public PlayerStatsSOB sayostats;

    public void onInteractCheckPoint()
    {
        if(CheckPointLoader.checkPointIndex < localIndex)
        {
            CheckPointLoader.checkPointIndex = localIndex;
            Debug.Log("Checkpoint " + localIndex + " reached");
            hinokastats.playerCurrentHealth = hinokastats.playerMaxHealth;
            yamistats.playerCurrentHealth = yamistats.playerMaxHealth;
            sayostats.playerCurrentHealth = sayostats.playerMaxHealth;
        }
    }
}
