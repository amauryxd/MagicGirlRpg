using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueWithResponse : MonoBehaviour
{
    [SerializeField] public DialogueResponse dialoguesSOB;
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private TextMeshProUGUI[] responseButtons;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image girlImage;
    private bool onSelectionState;
    private float typingTime = 0.05f;

    private bool didDialogueStart;
    private int lineIndex;

    public UnityEvent whatToDoAfterDialogue;

    public bool canStartDialogue = false;
    void changeStartDialogue()
    {
        canStartDialogue = !canStartDialogue;
    }
    void Update()
    {
        /*if (!didDialogueStart)
        {
            StartDialogue();
        }
        else if (dialogueText.text ==  dialoguesSOB.dialoguesElements[lineIndex].dialogues)//dialogues[lineIndex]
        {
            NextDialogueLine();
        }*/
    }
    [ContextMenu("EmpezarDialogo")]
    public void StartDialogue()
    {
        didDialogueStart = true;
        panelDialogue.SetActive(true);
        lineIndex = 0;
        girlImage.color = Color.white;
        nameText.text = dialoguesSOB.dialoguesElements[0].girlName.ToString();
        girlImage.sprite = dialoguesSOB.dialoguesElements[0].girlImage;

        StartCoroutine(ShowLine());
    }
    public void NextDialogueLine()
    {
        if (onSelectionState || !(dialogueText.text ==  dialoguesSOB.dialoguesElements[lineIndex].dialogues))
        {

            return;
        }
        lineIndex++;
        if (lineIndex < dialoguesSOB.dialoguesElements.Length)
        {
            nameText.text = dialoguesSOB.dialoguesElements[lineIndex].girlName.ToString();
            girlImage.sprite = dialoguesSOB.dialoguesElements[lineIndex].girlImage;
            StartCoroutine(ShowLine());
        }
        else
        {
            if(dialoguesSOB.isQuestion){
                for(int i = 0; i < responseButtons.Length; i++)
                {
                    girlImage.color = Color.grey;
                    responseButtons[i].text = dialoguesSOB.questionText[i];
                    responseButtons[i].transform.parent.gameObject.SetActive(true);
                }
                onSelectionState = true;
            }
            else
            {
                didDialogueStart = false;
                panelDialogue.SetActive(false);
                if(dialoguesSOB.doSomethingAtEnd)
                {
                    InvokeWhatToDoAfterDialogue();
                }
            }
        }
    }
    private IEnumerator ShowLine()
    {

        dialogueText.text = string.Empty;
        foreach (char ch in dialoguesSOB.dialoguesElements[lineIndex].dialogues)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        
    }
    public void buttonIndexChanger(int indexGetter)
    {
        //responseButtons[0].SetActive(false);
        for(int i = 0; i < responseButtons.Length; i++)
        {
            responseButtons[i].transform.parent.gameObject.SetActive(false);
        }
        onSelectionState = false;
        dialoguesSOB = dialoguesSOB.responsesMoreQuestions[indexGetter];
        girlImage.color = Color.white;
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    public void InvokeWhatToDoAfterDialogue()
    {
        whatToDoAfterDialogue.Invoke();
    }
}
