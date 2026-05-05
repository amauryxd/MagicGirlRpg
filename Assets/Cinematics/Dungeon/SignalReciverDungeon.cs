using UnityEngine;

public class SignalReciverDungeon : MonoBehaviour
{
    public Movement movement;
    public AudioSource audiosc;

    void Start()
    {
        movement.speed = 0;
    }

    public void DoOnComand()
    {
        movement.speed = 7;
        audiosc.Play();
    }
}
