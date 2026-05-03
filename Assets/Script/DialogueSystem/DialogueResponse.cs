using UnityEngine;

[CreateAssetMenu(fileName = "DialogueResponse", menuName = "Scriptable Objects/DialogueResponse")]
public class DialogueResponse : ScriptableObject
{
    public bool isQuestion;
    public bool doSomethingAtEnd;
    public DialoguesElementsResponses[] dialoguesElements;
    public string[] questionText;
    public DialogueResponse[] responsesMoreQuestions;

}
[System.Serializable]
public class DialoguesElementsResponses
{
    [TextArea(2,4)]public string dialogues;
    public GirlNames girlName;
    public Sprite girlImage;
    public float typingTime = 0.05f;
}
[System.Serializable]
public enum GirlNames
{
    Nozomi,
    Hinoka,
    Yami,
    Sayo,
    Desconocido
}
