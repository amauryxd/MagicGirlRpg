using UnityEngine;
using UnityEngine.EventSystems;

public class RealWorldManager : MonoBehaviour
{
    public static RealWorldManager Instance;
    public Canvas phoneCanvas;
    public GameObject phoneFirstButton;
    public DialogueWithResponse dialogueWithResponse;
    public Movement plyMov;
    public PlayerInteract playerInteract;
    public EventSystem eventListener;

    public RealWorldState currentState;
    void Awake()
    {
        Instance = this;
    }
    void OnEnable()
    {
        DialogueWithResponse.onDialogueFinish += DialogueFinGetter;
    }
    void OnDisable()
    {
        DialogueWithResponse.onDialogueFinish -= DialogueFinGetter;
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
                playerInteract.TryToIntaract();
                break;
            case RealWorldState.inPhone:

                break;
            case RealWorldState.inDialogue:
                dialogueWithResponse.NextDialogueLine();
                break;
        }
    }
    void FixedUpdate()
    {
        switch(currentState)
        {
            case RealWorldState.normal:
                plyMov.speed = 10;
                break;
            case RealWorldState.inPhone:
                plyMov.speed = 0;
                break;
            case RealWorldState.inDialogue:
                plyMov.speed = 0;
                break;
        }
    }
    void DialogueFinGetter(int id,bool doSomethingAtEnd)
    {
        currentState = RealWorldState.normal;
    }
    public void MenuChanger()
    {
       
        if(currentState == RealWorldState.normal)
        {
            phoneCanvas.gameObject.SetActive(true);
            currentState = RealWorldState.inPhone;
            eventListener.firstSelectedGameObject = phoneFirstButton;
            eventListener.SetSelectedGameObject(phoneFirstButton);
            return;
        }
        if(currentState == RealWorldState.inPhone)
        {
            currentState = RealWorldState.normal;
            phoneCanvas.gameObject.SetActive(false);
        }
    }

}
public enum RealWorldState
{
    normal,
    inPhone,
    inDialogue
}
