using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {Story,Fight,Underworld,Exploring,Pause}
    public static GameManager Instance { get; private set; }
    public GameState gameState;

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
}
