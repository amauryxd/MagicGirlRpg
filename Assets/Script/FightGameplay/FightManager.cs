using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public enum ActualTurn { Player, Enemy }
    public static FightManager Instance { get; private set;}
    [Header("FightVariables")]
    public List<AttackTurn> PlayerAttacks = new List<AttackTurn>();
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
