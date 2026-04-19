using System.Diagnostics.Tracing;
using UnityEngine;

public class DialogueManagerSetter : MonoBehaviour
{
    public static DialogueManagerSetter Instance;
    [SerializeField] private EventListener eventListener;
    [SerializeField] private DialogueWithResponse dialResp;
    void Awake()
    {
        Instance = this;
    }
    public void SetDialogueAndStart(DialogueResponse newDialogue, GameObject objectToHide = null)
    {
        if(objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
        dialResp.dialoguesSOB = newDialogue;
        dialResp.StartDialogue();
    }
    public void SetDialogueOnly(DialogueResponse newDialogue, GameObject objectToHide = null)
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
        dialResp.dialoguesSOB = newDialogue;
    }
}
