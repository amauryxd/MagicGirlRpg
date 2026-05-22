using UnityEngine;
using UnityEngine.UI;

public class PlayerAlliesAutoReference : MonoBehaviour
{
    [SerializeField] public PartyMemberStats stats;
    public int id;
    public AbilitesReference abilites;
    public TurnLogic turns;
    public NozomiTurn nozomiTurn;
    public ParticleSystem particles;
    public Slider plyHealth;
    bool canChangeAtack = false;
    void Start()
    {
        canChangeAtack = false;
    }

    void Update()
    {
        if(nozomiTurn == null)
        {
            if(stats.statsBase.playerCurrentHealth < 0)
            {
                stats.statsBase.playerCurrentAtaque = 1;
                canChangeAtack = true;
            }
            if(stats.statsBase.playerCurrentHealth > 0 && canChangeAtack)
            {
                stats.statsBase.playerCurrentAtaque = stats.statsBase.playerAtaqueBase;
                canChangeAtack = false;
            }
        }
    }
}
