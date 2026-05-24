using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TutorialStatics : MonoBehaviour
{
    public GameObject buttonsOptions;
    public GameObject ActionButt;
    public Animator MenuAnimations;
    public GameObject yourTurnText;
    public GameObject TutorialObject;
    public EventSystem eventSys;
    public GameObject nextButt;
    public static bool firstTime = true;
    public bool canStart;
    public bool canCheckDes;
    public bool isBossFight = false;
    private void Awake()
    {
        canStart = false;
        canCheckDes = false;
    }
    void Start()
    {
        if (!canStart)
        {
            MenuAnimations.SetTrigger("Hide");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!canStart)
        {
            buttonsOptions.SetActive(false);
            yourTurnText.SetActive(false);
        }
        if(firstTime && !TutorialObject.activeInHierarchy && canCheckDes)
        {
            buttonsOptions.SetActive(true);
            eventSys.SetSelectedGameObject(ActionButt);
            yourTurnText.SetActive(true);
            MenuAnimations.SetTrigger("Show");
            firstTime = false;
        }
    }
    public void StartAnimFinished()
    {
        canStart = true;
        if (!firstTime || isBossFight)
        {
            buttonsOptions.SetActive(true);
            eventSys.SetSelectedGameObject(ActionButt);
            yourTurnText.SetActive(true);
            MenuAnimations.SetTrigger("Show");
        }
        if (firstTime && !isBossFight)
        {
            TutorialObject.SetActive(true);
            eventSys.SetSelectedGameObject(nextButt);
            canCheckDes = true;
        }
    }
}
