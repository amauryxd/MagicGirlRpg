using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public int handsDestroyed = 0;
    public AudioSource music;
    public ParticleSystem shitThis;

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
    public void muteMusic()
    {
        music.Stop();
        shitThis.Stop();
    }
    //para cambio de scena en la muerte
}
