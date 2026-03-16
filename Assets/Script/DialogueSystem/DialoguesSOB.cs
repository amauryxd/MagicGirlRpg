using UnityEngine;

[CreateAssetMenu(fileName = "DialoguesSOB", menuName = "Scriptable Objects/DialoguesSOB")]
public class DialoguesSOB : ScriptableObject
{
    public DialoguesElements[] dialoguesElements;
}

[System.Serializable]
public class DialoguesElements
{
    [TextArea(2,4)]public string dialogues;
    public bool anexedText;
    public float typingTime;
}
