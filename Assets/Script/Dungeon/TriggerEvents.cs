using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public UnityEvent unityEvent;
    public bool detectHasBeenDungeon;
    private void Awake()
    {
        if (detectHasBeenDungeon)
        {
            if (HasBeenDungeon.hasBeen)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            unityEvent.Invoke();
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    
}
