using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public CaseIntaruactable hitInfoObj;
    private bool canIntaract;
    public void TryToIntaract()
    {
        if (hitInfoObj != null && canIntaract)
        {
            canIntaract = false;
            hitInfoObj.GetInteracted();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<CaseIntaruactable>(out CaseIntaruactable caseIntaruactable))
        {
            hitInfoObj = caseIntaruactable;
            canIntaract = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(hitInfoObj == null) return;
        if(collision.gameObject == hitInfoObj.gameObject)
        {
            hitInfoObj = null;
            canIntaract = true;
        }
    }
}
