using UnityEngine;

public class tempLogicPlayer : MonoBehaviour
{
    public TurnLogic temptest = new TurnLogic();
    public int idToManage;
    [ContextMenu("meter en cola")]
    public void queueSometing()
    {
        temptest.id = idToManage;
        FightManager.Instance.QueueAction(temptest);
    }
    [ContextMenu("Quitar de cola")]
    public void dequeueSomethin()
    {
        FightManager.Instance.DequeueAction();
    }
    [ContextMenu("Hacer Los ataques")]
    public void Attacar()
    {
        StartCoroutine(FightManager.Instance.DoTurns());
    }
}
