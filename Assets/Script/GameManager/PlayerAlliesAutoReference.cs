using UnityEngine;

public class PlayerAlliesAutoReference : MonoBehaviour
{
    [SerializeField] public PartyMemberStats stats;
    public int id;
    public AbilitesReference abilites;
    public TurnLogic turns;
    public NozomiTurn nozomiTurn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
