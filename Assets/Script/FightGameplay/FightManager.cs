using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public enum ActualTurn { Player, Enemy }
    public static FightManager Instance { get; private set; }
    [Header("FightVariables")]
    public List<AttackTurn> PlayerAttacks = new List<AttackTurn>();
    [Header("EnemysVariables")]
    public List<EnemyHealth> enemies = new List<EnemyHealth>();
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QueueAction(AttackTurn attackTurnToQueue)
    {
        PlayerAttacks.Add(attackTurnToQueue);
        //debug
        Debug.Log(PlayerAttacks.Count);
    }

    public void DequeueAction()
    {
        PlayerAttacks.RemoveAt(PlayerAttacks.Count - 1);
        //debug
        Debug.Log(PlayerAttacks.Count);
    }
}
