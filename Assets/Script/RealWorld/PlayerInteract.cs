using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    public CaseIntaruactable hitInfoObj;
    private bool canIntaract;
    public void TryToIntaract()
    {
        Debug.Log("tratando de ahacer algo");
        if (hitInfoObj != null && canIntaract)
        {
            canIntaract = false;
            hitInfoObj.GetInteracted();
            Debug.Log("interactuando pero player");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("colisionando con algo");
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
