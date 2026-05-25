using UnityEngine;

public class DoorScripts : MonoBehaviour
{
    public Animator anim;
    public int doorIndex;
    public void OpenDoor()
    {
//        RealWorldManager.Instance.currentState = RealWorldState.onCinematic;
        anim.SetTrigger("Open");
        if(doorIndex == 1)
        {
            DungeonManager.Door1 = false;
        }
        else if(doorIndex == 2)
        {
            DungeonManager.Door2 = false;
        }
    }
        public void ChangeToNormal()
    {
        DungeonManager.Instance.dungeonStates = DungeonStates.Normal;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
