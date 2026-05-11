using UnityEngine;

public class DoorScripts : MonoBehaviour
{
    public Animator anim;

    public void OpenDoor()
    {
//        RealWorldManager.Instance.currentState = RealWorldState.onCinematic;
        anim.SetTrigger("Open");
    }
    public void resetThings()
    {
        //RealWorldManager.Instance.currentState = RealWorldState.normal;
    }
}
