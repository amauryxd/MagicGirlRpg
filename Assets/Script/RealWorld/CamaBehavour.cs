using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaBehavour : MonoBehaviour
{
    public DialogosHolder dialogosHolder;
    public int howManyReady;
    public string SceneToLoad;
    public Animator fadein;
    public Animator musicF;
    private bool canInteract;
    void OnEnable()
    {
        DialogueWithResponse.onDialogueFinish += AfterFinishDialogue;
        canInteract = true;
    }
    void OnDisable()
    {
        DialogueWithResponse.onDialogueFinish -= AfterFinishDialogue;
    }
    public void IncrementReady()
    {
        howManyReady++;
    }
    public void WhatToDo()
    {
        if(howManyReady < 2)
        {
            dialogosHolder.SetDialogueToStart();
        }
        else
        {
            dialogosHolder.ChangeThisDialogue();
            dialogosHolder.SetDialogueToStart();
        }
    }
    public void AfterFinishDialogue(int id, bool doSomethingAtEnd)
    {
        Debug.Log("Dialogue finished with id: " + id + " and doSomethingAtEnd: " + doSomethingAtEnd+" and canInteract: " + canInteract);
        if (doSomethingAtEnd && id == dialogosHolder.idToIdentify && canInteract)
        {
            canInteract = false;
            StartCoroutine(toFinish());
        }
    }
    public IEnumerator toFinish()
    {
        fadein.SetTrigger("Do");
        musicF.SetTrigger("MDown");
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneToLoad);
    }
}
