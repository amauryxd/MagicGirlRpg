using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFIghtRef : MonoBehaviour
{
    [Header("First Buttons")]
    public Button actionBut;
    public Button escapeBut;
    public Button itemBut;
    public Canvas canvaOptions;
    [Header("OnPlayer Select")]
    public Button att1But;
    public TextMeshProUGUI att1Text;
    public Button att2But;
    public TextMeshProUGUI att2Text;
    public Button statBut;
    public TextMeshProUGUI statText;
    public Button DefenceBut;
    public Canvas canvaAbilities;

    private FightManager fightInstance;

    void Start()
    {
        fightInstance = FightManager.Instance;
    }
    public void SendButtonLogic(int index)
    {
        fightInstance.LogicButtons(index);
    }
    public void SendButtonIndex(int index)
    {
        fightInstance.QueueAction(index);
    }
    void Update()
    {
        PopulateAbilites();
    }
    public void PopulateAbilites()
    {
        att1Text.SetText(FightManager.Instance.partyMembers[FightManager.Instance.partyIndex+1].abilites.firstAbility.abilityName);
        att2Text.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbility.abilityName);
        statText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.statAbility.abilityName);
    }
}
