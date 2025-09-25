using UnityEngine;

public class tempLogicPlayer : MonoBehaviour
{
    public AttackTurn temptest = new AttackTurn();
    [ContextMenu("meter en cola")]
    public void queueSometing()
    {
        FightManager.Instance.QueueAction(temptest);
    }
    [ContextMenu("Quitar de cola")]
    public void dequeueSomethin()
    {
        FightManager.Instance.DequeueAction();
    }
}
