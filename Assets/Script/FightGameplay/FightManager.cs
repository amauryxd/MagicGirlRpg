using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class FightManager : MonoBehaviour
{
    public enum ActualTurn { Player, Enemy }
    [Header("Manage for Fight variables")]
    public ActualTurn turnActual = ActualTurn.Player;
    public static FightManager Instance { get; private set; }
    [Header("PlayerVariables")]
    public List<PlayerAlliesAutoReference> partyMembers = new List<PlayerAlliesAutoReference>();
    public List<TurnLogic> PlayerAttacks = new List<TurnLogic>();
    public int partyIndex;
    [SerializeField] private bool canPassTurn;
    [Header("EnemysVariables")]
    public List<EnemyHealth> enemies = new List<EnemyHealth>();
    private int enemiesIndex = 0;
    [Header("Camera")]
    public CinemachineCamera cineCamera;
    [Header("Canvas")]
    [SerializeField] public CanvasFIghtRef canvasRef;
    private bool canSelectEnemies = false;
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
    }
    void OnDisable()
    {
        TurnLogic.turnFinished -= NextTurnSetter;
    }
    void Start()
    {
        //temp to test
        partyMembers = GameManager.Instance.partyMembers;
        partyIndex = 0;
        inputs = partyMembers[0].GetComponent<InputHandler>();
    }


    void FixedUpdate()
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
        if (canSelectEnemies)
        {
            SelectEnemy();
        }
    }

    public void PlayerTurnLogic()
    {
        //cambiar el squema de controles a ataque
        //GameManager.Instance.inputRef.SwitchCurrentActionMap("OnFight");
        //ir coleccionando todos los ataques hasta tener 3
        //comprobar el tipo de turno
        //ir ejecutando 1 por 1 hasta que termine la lista
        //limpiar lista
        //lanzar evento de turno finalizado
    }

    public void EnemyTurnLogic()
    {
        //poner en una fila los attaques de los enemigos
        //ir ejecutando uno por uno hasta que todos terminen
        //lanzar el evento de turno finalizado
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
    public IEnumerator DoTurns()
    {
        for (int index = 0; index < PlayerAttacks.Count; index++)
        {
            PlayerAttacks[index].MakeTurn();
            yield return new WaitUntil(() => canPassTurn);
            canPassTurn = false;
        }
    }
    private void NextTurnSetter()
    {
        canPassTurn = true;
    }
    #region Turn Logic
    private void StartTurn()
    {
        ActivateCamera();
        partyIndex = 0;
        MoveCameraTo(partyMembers[partyIndex + 1].transform);
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
            SetTurnLogic(enemiesIndex);
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
        }
    }
    public void FinishTurn()
    {
        DesactivateCamera();
        enemiesIndex = 0;
        partyIndex = 0;
        StartCoroutine(DoTurns());
    }
    private void SelectAlly()
    {

    }
    public void SetTurnLogic(int index)
    {
        TurnLogic tempLogic = new TurnLogic();
        tempLogic = partyMembers[partyIndex+1].turns;
        tempLogic.id = index;
        tempLogic.Type = TurnLogic.TurnType.Attack;
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
                StartTurn();
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

                break;
            case 2:
                SelectAlly();
                break;
            case 3:

                break;
        }
    }
    
    #endregion

}
