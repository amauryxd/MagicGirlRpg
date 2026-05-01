using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemObjectChanger : MonoBehaviour
{
    public GameObject buttonToChage;
    public EventSystem eventSystem;
    
    public void ChangeSelectedObject()
    {
        eventSystem.SetSelectedGameObject(buttonToChage);
    }
}
