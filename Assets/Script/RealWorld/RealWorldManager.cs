using UnityEngine;
using UnityEngine.EventSystems;

public class RealWorldManager : MonoBehaviour
{
    public static RealWorldManager Instance;
    public Canvas phoneCanvas;
    public GameObject phoneFirstButton;
    public DialogueWithResponse dialogueWithResponse;
    public Movement plyMov;
    public EventSystem eventListener;

    public RealWorldState currentState;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentState = RealWorldState.normal;
    }
    public void DoOnConfirm()
    {
        switch(currentState)
        {
            case RealWorldState.normal:

                break;
            case RealWorldState.inPhone:

                break;
            case RealWorldState.inDialogue:
                dialogueWithResponse.NextDialogueLine();
                break;
        }
    }
    public void MenuChanger()
    {
       
        if(currentState == RealWorldState.normal)
        {
            phoneCanvas.gameObject.SetActive(true);
            currentState = RealWorldState.inPhone;
            plyMov.speed = 0;
            eventListener.firstSelectedGameObject = phoneFirstButton;
            eventListener.SetSelectedGameObject(phoneFirstButton);
            return;
        }
        if(currentState == RealWorldState.inPhone)
        {
            currentState = RealWorldState.normal;
            phoneCanvas.gameObject.SetActive(false);
            plyMov.speed = 5;
        }
    }

}
public enum RealWorldState
{
    normal,
    inPhone,
    inDialogue
}
