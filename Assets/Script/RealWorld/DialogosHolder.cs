using UnityEngine;
using UnityEngine.Events;

public class DialogosHolder : MonoBehaviour
{
    public int idToIdentify;
    public DialogueResponse dialogue;
    public DialogueResponse newDialogueToSet;
    public bool changeThisDialogue;
    public UnityEvent toDoAfterDialogue;

    void OnEnable()
    {
        DialogueWithResponse.onDialogueFinish += ToDoAfterDialogue;
    }
    void OnDisable()
    {
        DialogueWithResponse.onDialogueFinish -= ToDoAfterDialogue;
    }
    public void SetDialogueToStart()
    {
        DialogueManagerSetter.Instance.SetDialogueAndStart(dialogue,null,idToIdentify);
        RealWorldManager.Instance.currentState = RealWorldState.inDialogue;
        if (changeThisDialogue)
        {
            dialogue = newDialogueToSet;
        }
    }

    public void OnlySetDialogue()
    {
        DialogueManagerSetter.Instance.SetDialogueOnly(dialogue);
        if (changeThisDialogue)
        {
            dialogue = newDialogueToSet;
        }
    }
    public void ChangeThisDialogue()
    {
        dialogue = newDialogueToSet;
    }
    public void ToDoAfterDialogue(int id, bool doSomethingAtEnd)
    {
        if (doSomethingAtEnd && id == idToIdentify)
        {
            toDoAfterDialogue.Invoke();
        }
    }
}
