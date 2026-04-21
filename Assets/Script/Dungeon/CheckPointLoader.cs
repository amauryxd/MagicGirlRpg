using UnityEngine;

public class CheckPointLoader : MonoBehaviour
{
    public Transform player;
    public CheckPointsSOB chpoIndex;
    public Transform[] checkpoints;

    void Awake()
    {
        player.position = checkpoints[chpoIndex.checkPointIndex].position;
    }
}
