using UnityEngine;

public class onEventGetResponseIndex : MonoBehaviour
{
    public int indexResponse;
    public DialogueWithResponse dialogueWithResponse;
    public void getClicked()
    {
        dialogueWithResponse.buttonIndexChanger(indexResponse);
    }
}
