using System.Collections.Generic;
using UnityEngine;

public class CheckPointLoader : MonoBehaviour
{
    public Transform player;
    public CheckPointsSOB chpoIndex;
    public List<Transform> checkpoints;

    void Awake()
    {
        player.position = checkpoints[chpoIndex.checkPointIndex].position;
    }
}
