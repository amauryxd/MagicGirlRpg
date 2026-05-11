using UnityEngine;

public class ButonScripts : MonoBehaviour
{
    public SpriteRenderer sprite;
    public void ChangeColor()
    {
        sprite.color = Color.grey;
    }
    public void ChangeStateToCinematic()
    {
        DungeonManager.Instance.dungeonStates = DungeonStates.cinematic;
    }

}
