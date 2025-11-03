using UnityEngine;

public class ActionAssigner : InputHandler
{
    private TurnLogic turnThis;
    void Start()
    {
        turnThis = GetComponent<TurnLogic>();
    }
    private void SelectEnemyTarget()
    {
        FightManager.Instance.MoveCameraTo(FightManager.Instance.enemies[0].transform);
    }
}
