using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState {Story,Fight,Underworld,Exploring,Pause}
    public static GameManager Instance { get; private set; }
    [Header("State Variables")]
    public GameState gameState;
    [Header("Input Variables")]
    [SerializeField] public PlayerInput inputRef;
    [Header("Fight Variables")]
    public List<PlayerAlliesAutoReference> partyMembers = new List<PlayerAlliesAutoReference>();

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
        switch (gameState)
        {
            case GameState.Story:
                break;
            case GameState.Underworld:
                break;
            case GameState.Fight:
                FightStateLogic();
                break;
            case GameState.Exploring:
                break;
            case GameState.Pause:
                break;
        }
    }

    private void FightStateLogic()
    {
        
    }
}
