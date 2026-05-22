using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public int handsDestroyed = 0;

    public bool CheckHandDestroyed()
    {
        if(handsDestroyed >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //para cambio de scena en la muerte
}
