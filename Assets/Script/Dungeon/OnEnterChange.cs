using UnityEngine;

public class OnEnterChange : MonoBehaviour
{
    public changeSceneString scString;
    public string sceneToChange;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            scString.sceneToChange(sceneToChange);
    }
}
