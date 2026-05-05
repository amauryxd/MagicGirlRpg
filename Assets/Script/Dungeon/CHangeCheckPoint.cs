using UnityEngine;

public class CHangeCheckPoint : MonoBehaviour
{
    public CheckPointsSOB chpoIndex;
    public int localIndex;

    public void onInteractCheckPoint()
    {
        if(chpoIndex.checkPointIndex < localIndex)
        {
            chpoIndex.checkPointIndex = localIndex;
            Debug.Log("Checkpoint " + localIndex + " reached");
        }
    }
}
