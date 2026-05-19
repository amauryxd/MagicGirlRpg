using UnityEngine;

public class OnEnterChange : MonoBehaviour
{
    public changeSceneString scString;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            scString.sceneToChange("Dungeon2");
    }
}
