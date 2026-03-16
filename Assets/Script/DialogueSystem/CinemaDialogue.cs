using System.Collections;
using TMPro;
using UnityEngine;

public class CinemaDialogue : MonoBehaviour
{
    [SerializeField] private DialoguesSOB dialoguesSOB;
    [SerializeField] private GameObject panelDialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private float typingTime = 0.05f;

    private bool didDialogueStart;
    private int lineIndex;

    public bool canStartDialogue;
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
    [ContextMenu("EmpezarDialogoCinema")]
    public void StartDialogue()
    {
        didDialogueStart = true;
        panelDialogue.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    [ContextMenu("Siguiente linea")]
    public void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialoguesSOB.dialoguesElements[0].dialogues.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            panelDialogue.SetActive(false);

        }
    }
    private IEnumerator ShowLine()
    {
        if(!dialoguesSOB.dialoguesElements[lineIndex].anexedText)
        {
            dialogueText.text = string.Empty;
        }
        foreach (char ch in dialoguesSOB.dialoguesElements[lineIndex].dialogues)
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        
    }
}
