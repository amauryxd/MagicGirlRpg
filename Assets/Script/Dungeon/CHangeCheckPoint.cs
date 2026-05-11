using UnityEngine;

public class CHangeCheckPoint : MonoBehaviour
{
    public int localIndex;

    public void onInteractCheckPoint()
    {
        if(CheckPointLoader.checkPointIndex < localIndex)
        {
            CheckPointLoader.checkPointIndex = localIndex;
            Debug.Log("Checkpoint " + localIndex + " reached");
        }
    }
}
