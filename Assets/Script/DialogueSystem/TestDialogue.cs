using System.Collections;
using TMPro;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    [SerializeField, TextArea(4, 6)] private string[] dialogues;
    [SerializeField] GameObject panelDialogue;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private float typingTime = 0.05f;

    private bool didDialogueStart;
    private int lineIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogues[lineIndex])
            {
            NextDialogueLine();
            }
        }
        
    }
    [ContextMenu("EmpezarDialogo")]
    void StartDialogue()
    {
        didDialogueStart = true;
        panelDialogue.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogues.Length)
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
        dialogueText.text = string.Empty;
        foreach (char ch in dialogues[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
        
    }
}
