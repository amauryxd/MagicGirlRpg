using UnityEngine;

public class SignalReciverDungeon : MonoBehaviour
{
    public Movement movement;
    public AudioSource audiosc;

    void Start()
    {
        if (!HasBeenDungeon.hasBeen)
        {
            DungeonManager.Instance.dungeonStates = DungeonStates.cinematic;
        }
        else
        {
            DungeonManager.Instance.dungeonStates = DungeonStates.Normal;
            audiosc.Play();
        }
    }

    public void DoOnComand()
    {
        DungeonManager.Instance.dungeonStates = DungeonStates.Normal;
        audiosc.Play();
    }
}
