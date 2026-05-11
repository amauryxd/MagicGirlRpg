using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour
{
    public Transform player;
    public static int checkPointIndex;
    public List<Transform> checkpoints;

    void Awake()
    {
        player.position = checkpoints[checkPointIndex].position;
    }
}
