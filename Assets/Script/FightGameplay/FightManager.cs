using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class FightManager : MonoBehaviour
{
    public enum ActualTurn { Player, Nozomi, Enemy, CheckWinnerPlayer, CheckWinnerEnemy}
    [Header("Manage for Fight variables")]
    public ActualTurn turnActual = ActualTurn.Player;
    public static FightManager Instance { get; private set; }
    private bool onPlayerTurn = false;
    private bool onEnemyTurn = false;
    private bool onCheckTurn = false;
    [Header("PlayerVariables")]
    public List<PlayerAlliesAutoReference> partyMembers = new List<PlayerAlliesAutoReference>();
    public List<TurnLogic> PlayerAttacks = new List<TurnLogic>();
    public int partyIndex;
    [SerializeField] private bool canPassTurn;
    [Header("EnemysVariables")]
    public List<EnemyHealth> enemies = new List<EnemyHealth>();
    public int enemiesIndex = 0;
    [Header("Camera")]
    public CinemachineCamera cineCamera;
    [Header("Canvas")]
    [SerializeField] public CanvasFIghtRef canvasRef;
    private bool canSelectEnemies = false;
    private bool canSelectAlly = false;
    public int selectAllysIndex = 0;
    InputHandler inputs;
    private bool canSelect = false;

    //[Header()]
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
    void OnEnable()
    {
        TurnLogic.turnFinished += NextTurnSetter;
        AttackTurnEnemy.turnFinishedEnemy += NextTurnSetter;
    }
    void OnDisable()
    {
        TurnLogic.turnFinished -= NextTurnSetter;
        AttackTurnEnemy.turnFinishedEnemy -= NextTurnSetter;
    }
    void Start()
    {
        //temp to test
        partyMembers = GameManager.Instance.partyMembers;
        partyIndex = 0;
        inputs = partyMembers[0].GetComponent<InputHandler>();
        onEnemyTurn = false;
        onCheckTurn = false;
        onPlayerTurn = false;
    }


    void FixedUpdate()
    {
        switch (turnActual)
        {
            case ActualTurn.Player:
                if(!onPlayerTurn)
                    PlayerTurnLogic();
                break;
            case ActualTurn.Nozomi:
                NozomiTurnLogic();
                break;
            case ActualTurn.CheckWinnerPlayer:
                if(!onCheckTurn)
                    CheckWinnerPlayer();
                break;
            case ActualTurn.Enemy:
                if(!onEnemyTurn)
                    EnemyTurnLogic();
                break;
            case ActualTurn.CheckWinnerEnemy:
                if(!onCheckTurn)
                    CheckWinnerEnemy();
                break;
            default:
                break;
        }
        if (canSelectEnemies)
        {
            SelectEnemy();
        }
        if (canSelectAlly)
        {
            SelectAlly();
        }
    }
    void NozomiTurnLogic()
    {
        onPlayerTurn = false;
        partyMembers[0].GetComponent<NozomiTurn>().DoTheAbilities();
        PlayerAttacks.Clear();
        turnActual = ActualTurn.CheckWinnerPlayer;
    }
    public void PlayerTurnLogic()
    {
        Debug.Log("Player Turn Started");
        canvasRef.canvaOptions.enabled = true;
        onPlayerTurn = true;
        //cambiar el squema de controles a ataque
        //GameManager.Instance.inputRef.SwitchCurrentActionMap("OnFight");
        //ir coleccionando todos los ataques hasta tener 3
        //comprobar el tipo de turno
        //ir ejecutando 1 por 1 hasta que termine la lista
        //limpiar lista
        //lanzar evento de turno finalizado
    }
    #region EnemyTurnLogic
    public void EnemyTurnLogic()
    {
        StartCoroutine(DoTurnsEnemies());
        onEnemyTurn = true;
        //poner en una fila los attaques de los enemigos
        //ir ejecutando uno por uno hasta que todos terminen
        //lanzar el evento de turno finalizado
    }
    public IEnumerator DoTurnsEnemies()
    {
        for (int index = 0; index < enemies.Count; index++)
        {
            enemies[index].GetComponent<AttackTurnEnemy>().AttackTo();
            yield return new WaitUntil(() => canPassTurn);
            canPassTurn = false;
        }
        turnActual = ActualTurn.CheckWinnerEnemy;
    }
    #endregion
    public void CheckWinnerPlayer()
    {
        if(enemies.Count <= 0)
        {
            Debug.Log("You Win");
            //Win Logic
            onCheckTurn = false;
            return;
        }
        else
        {
            Debug.Log("Continue Fight player");
            turnActual = ActualTurn.Enemy;
            onCheckTurn = false;
            return;
        }
    }
    public void CheckWinnerEnemy()
    {
        onEnemyTurn = false;
        for(int index = 0; index < partyMembers.Count; index++)
        {
            if(partyMembers[index].name != "Nozomi"){
                if(partyMembers[index].stats.statsLocal.PlayerCurrentHealth > 0)
                {
                    Debug.Log("Continue Fight enemy");
                    onCheckTurn = false;
                    turnActual = ActualTurn.Player;
                    return;
                }
                else
                {
                    Debug.Log("You Lose");
                    //Lose Logic
                    onCheckTurn = false;
                    return;
                }
            }
        }
    }
    public void QueueAction(TurnLogic attackTurnToQueue)
    {
        PlayerAttacks.Add(attackTurnToQueue);
        //debug
    }
    public void DequeueAction()
    {
        PlayerAttacks.RemoveAt(PlayerAttacks.Count - 1);
        //debug
        Debug.Log(PlayerAttacks.Count);
    }
    public IEnumerator DoTurnsPlayer()
    {
        for (int index = 0; index < PlayerAttacks.Count; index++)
        {
            PlayerAttacks[index].MakeTurn();
            yield return new WaitUntil(() => canPassTurn);
            canPassTurn = false;
        }
        turnActual = ActualTurn.Nozomi;
    }
    private void NextTurnSetter()
    {
        canPassTurn = true;
    }
    #region Turn Logic Player
    private void StartTurnPlayer()
    {
        ActivateCamera();
        partyIndex = 0;
        MoveCameraTo(partyMembers[partyIndex + 1].transform);
        cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = 2.5f;
        cineCamera.GetComponent<CinemachineFollow>().FollowOffset.y = 0f;
    }
    private void SelectEnemy()
    {
        if (!inputs.onConfirm)
        {
            canSelect = true;
        }
        enemiesIndex = Mathf.Clamp(enemiesIndex, 0, enemies.Count - 1);
        MoveCameraTo(enemies[enemiesIndex].transform);
        cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = -2.5f;
        cineCamera.GetComponent<CinemachineFollow>().FollowOffset.y = 2f;
        if (inputs.fightMove > 0)
        {
            enemiesIndex++;
        }
        else if (inputs.fightMove < 0)
        {
            enemiesIndex--;
        }
        if (inputs.onConfirm && canSelect)
        {
            canSelect = false;
            SetTurnLogic(partyIndex+1,enemiesIndex,TurnLogic.TurnType.Attack);
            canSelectEnemies = false;
            partyIndex++;
            if (partyIndex > 2)
            {
                FinishTurn();
            }
            else
            {
                MoveCameraTo(partyMembers[partyIndex + 1].transform);
                cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = 2.5f;
                cineCamera.GetComponent<CinemachineFollow>().FollowOffset.y = 0f;
                canvasRef.canvaAbilities.enabled = true;
            }
        }
        if (inputs.onNegate)
        {
            canvasRef.canvaAbilities.enabled = true;
            canSelectEnemies = false;
            canSelect = false;
            MoveCameraTo(partyMembers[partyIndex + 1].transform);
            cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = 2.5f;
            cineCamera.GetComponent<CinemachineFollow>().FollowOffset.y = 0f;
            DequeueAction();
        }
    }
    public void FinishTurn()
    {
        canvasRef.canvaAbilities.enabled = false;
        DesactivateCamera();
        enemiesIndex = 0;
        partyIndex = 0;
        selectAllysIndex = 0;
        StartCoroutine(DoTurnsPlayer());
    }
    private void SelectAlly()
    {
        if (!inputs.onConfirm)
        {
            canSelect = true;
        }
        selectAllysIndex = Mathf.Clamp(selectAllysIndex, 0, partyMembers.Count - 2);
        MoveCameraTo(partyMembers[selectAllysIndex + 1].transform);
        cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = 2.5f;
        if (inputs.fightMove > 0)
        {
            selectAllysIndex++;
        }
        else if (inputs.fightMove < 0)
        {
            selectAllysIndex--;
        }
        if (inputs.onConfirm && canSelect)
        {
            canSelect = false;
            SetTurnLogic(partyIndex+1,selectAllysIndex,TurnLogic.TurnType.StatModif);
            canSelectAlly = false;
            partyIndex++;
            if (partyIndex > 2)
            {
                FinishTurn();
            }
            else
            {
                MoveCameraTo(partyMembers[partyIndex + 1].transform);
                canvasRef.canvaAbilities.enabled = true;
                cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = 2.5f;
            }
        }
        if (inputs.onNegate)
        {
            canvasRef.canvaAbilities.enabled = true;
            canSelectAlly = false;
            canSelect = false;
            MoveCameraTo(partyMembers[partyIndex + 1].transform);
            cineCamera.GetComponent<CinemachineFollow>().FollowOffset.x = 2.5f;
        }
    }
    public void SetTurnLogic(int fromWho,int index, TurnLogic.TurnType type)
    {
        TurnLogic tempLogic = new TurnLogic();
        tempLogic = partyMembers[fromWho].turns;
        tempLogic.id = index;
        tempLogic.Type = type;
        QueueAction(tempLogic);
    }
    #endregion
    
    #region CameraMovement
    public void MoveCameraTo(Transform newObjective)
    {
        cineCamera.Follow = newObjective;
    }
    public void ActivateCamera()
    {
        cineCamera.gameObject.SetActive(true);
    }
    public void DesactivateCamera()
    {
        cineCamera.gameObject.SetActive(false);
    }
    #endregion

    #region ActionLogic
    public void LogicButtons(int index)
    {
        switch (index)
        {
            case 0:
                StartTurnPlayer();
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
    public void QueueAction(int index)
    {
        switch (index)
        {
            case 0:
                enemiesIndex = 0;
                canSelectEnemies = true;
                break;
            case 1:
                SetTurnLogic(partyIndex + 1, 0, TurnLogic.TurnType.AllAttack);
                partyIndex++;
                if (PlayerAttacks.Count > 2)
                {
                    FinishTurn();
                }
                else
                {
                    MoveCameraTo(partyMembers[partyIndex + 1].transform);
                    canvasRef.canvaAbilities.enabled = true;
                }
                break;
            case 2:
                selectAllysIndex = 0;
                canSelectAlly = true;
                break;
            case 3:
                SetTurnLogic(partyIndex+1,0, TurnLogic.TurnType.Defense);
                partyIndex++;
                if(PlayerAttacks.Count > 2)
                {
                    FinishTurn();
                }
                else
                {
                    MoveCameraTo(partyMembers[partyIndex + 1].transform);
                    canvasRef.canvaAbilities.enabled = true;
                }
                break;
        }
    }
    
    #endregion

}
