using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public enum ActualTurn { Player, Enemy }
    [Header("Manage for Fight variables")]
    public ActualTurn turnActual = ActualTurn.Player;
    public static FightManager Instance { get; private set; }
    [Header("FightVariables")]
    public List<TurnLogic> PlayerAttacks = new List<TurnLogic>();
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
        switch (turnActual)
        {
            case ActualTurn.Player:
                PlayerTurnLogic();
                break;
            case ActualTurn.Enemy:
                EnemyTurnLogic();
                break;
            default:
                break;
        }
    }

    public void PlayerTurnLogic()
    {
        //ir coleccionando todos los ataques hasta tener 3
        //comprobar el tipo de turno
        //ir ejecutando 1 por 1 hasta que termine la lista
        //limpiar lista
    }

    public void EnemyTurnLogic()
    {
        
    }

    public void QueueAction(TurnLogic attackTurnToQueue)
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
