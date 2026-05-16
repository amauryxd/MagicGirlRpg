using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasFIghtRef : MonoBehaviour
{
    [Header("First Buttons")]
    public Button actionBut;
    public Button escapeBut;
    public Button itemBut;
    public GameObject canvaOptions;
    [Header("OnPlayer Select")]
    public Button att1But;
    public TextMeshProUGUI att1Text;
    public Button att2But;
    public TextMeshProUGUI att2Text;
    public Button statBut;
    public TextMeshProUGUI statText;
    public Button DefenceBut;
    public GameObject canvaAbilities;
    public EventSystem eventSystem;
    private FightManager fightInstance;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image iconDown;

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
        //PopulateAbilites();
        ChangeButtonEvent();
    }
    public void PopulateAbilites()
    {
        if(fightInstance.partyMembers[fightInstance.partyIndex+1].stats.statsBase.playerDrive >= 100)
        {
            att1Text.SetText(FightManager.Instance.partyMembers[FightManager.Instance.partyIndex+1].abilites.firstAbilityDrive.abilityName);
            att2Text.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbilityDrive.abilityName);
            statText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.statAbility.abilityName);
        }else{
            att1Text.SetText(FightManager.Instance.partyMembers[FightManager.Instance.partyIndex+1].abilites.firstAbility.abilityName);
            att2Text.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbility.abilityName);
            statText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.statAbility.abilityName);
        }
    }
    public bool isDrivenCharacter()
    {
        if(fightInstance.partyMembers[fightInstance.partyIndex+1].stats.statsBase.playerDrive >= 100)
        {
            return true;
        }else{
            return false;
        }
    }
    public void ChangeButtonEvent()
    {
        switch (eventSystem.currentSelectedGameObject.name)
        {
            case "ButAt1":
                if (isDrivenCharacter())
                {
                    titleText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.firstAbilityDrive.abilityName);
                    descriptionText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.firstAbilityDrive.abilityDesc);
                    //iconDown.sprite = fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.firstAbilityDrive.abilityIcon;
                }
                else
                {
                    titleText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.firstAbility.abilityName);
                    descriptionText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.firstAbility.abilityDesc);
                }
                break;
            case "ButAt2":
                if (isDrivenCharacter())
                {
                    titleText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbilityDrive.abilityName);
                    descriptionText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbilityDrive.abilityDesc);
                    //iconDown.sprite = fightInstance.partyMembers[fightInstance.partyIndex+1].abilites..abilityIcon;
                }
                else
                {
                    titleText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbility.abilityName);
                    descriptionText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.secondAbility.abilityDesc);
                }
                break;
            case "ButStat":
                    titleText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.statAbility.abilityName);
                    descriptionText.SetText(fightInstance.partyMembers[fightInstance.partyIndex+1].abilites.statAbility.abilityDesc);
                    //iconDown.sprite = fightInstance.partyMembers[fightInstance.partyIndex+1].abilites..abilityIcon;
                break;
            case "ButDef":
                titleText.SetText("¡Protégete!");
                descriptionText.SetText("Toma una posición defensiva y reduce el daño recibido en el siguiente turno.");
            break;
            default:
            break;
        }
    }
}
