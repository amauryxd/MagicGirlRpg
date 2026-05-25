using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour
{
    public CaseIntaruactable hitInfoObj;
    public bool canIntaract;
    public Coroutine activeCoroutine;
    public AnimationReference animsDungeon;
    void OnEnable()
    {
        DialogueWithResponse.onDialogueFinish += ReactivateInteract;
    }
    void OnDisable()
    {
        DialogueWithResponse.onDialogueFinish -= ReactivateInteract;
    }
    public void TryToIntaract()
    {
        if (hitInfoObj != null && canIntaract)
        {
            canIntaract = false;
            hitInfoObj.GetInteracted();
            if(animsDungeon != null )
            {
                animsDungeon.animsInteract();
            }
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
        if(activeCoroutine != null)
        StopCoroutine(activeCoroutine);
        if(hitInfoObj == null) return;
        if(collision.gameObject == hitInfoObj.gameObject)
        {
            hitInfoObj = null;
            canIntaract = true;
        }
    }
    void ReactivateInteract(int id, bool doSomethingAtEnd)
    {
        activeCoroutine =StartCoroutine(ReactivateAfterTime(0.5f));
    }
    public IEnumerator ReactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        canIntaract = true;
    }
}
