using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour
{
    public Transform player;
    public static int checkPointIndex;
    public List<Transform> checkpoints;

    void Start()
    {
        if(DungeonManager.HasLost)
        {
            player.position = checkpoints[checkPointIndex].position;
            DungeonManager.HasLost = false;
        }
        else
        {
            player.position = DungeonManager.playerLastPos;
            DungeonManager.HasLost = false;
        }
    }
}
