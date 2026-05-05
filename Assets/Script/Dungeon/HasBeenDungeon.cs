using UnityEngine;

public class HasBeenDungeon : MonoBehaviour
{
    public static bool hasBeen;
    public GameObject DirectorOBJ;

    void Start()
    {
        if (hasBeen)
        {
            DirectorOBJ.SetActive(false);
        }
    }
    public void changeBeen()
    {
        hasBeen = true;
    }
}
