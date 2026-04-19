using UnityEngine;

public class DialogosHolder : MonoBehaviour
{
    public DialogueResponse dialogue;
    public DialogueResponse newDialogueToSet;
    public bool changeThisDialogue;

    public void SetDialogueToStart()
    {
        DialogueManagerSetter.Instance.SetDialogueAndStart(dialogue);
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
}
