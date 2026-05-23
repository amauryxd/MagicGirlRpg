using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance { get; private set;}
    public EventSystem eventSystem;
    public DungeonStates dungeonStates;
    public Movement playerMv;
    public static bool Door1 = true;
    public static bool Door2 = true;
    public List<GameObject> doorsList;
    public List<GameObject> ButtonsList;
    public static Vector2 playerLastPos;
    public PlayerInteract plyInter;
    public DialogueWithResponse dialogues;
    public static bool HasLost = false;
    public TutorialDungeon tuto;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CheckDoors();
    }
    void OnEnable()
    {
        DialogueWithResponse.onDialogueFinish += TheDialogueFinished;
    }
    void OnDisable()
    {
        DialogueWithResponse.onDialogueFinish -= TheDialogueFinished;
    }
    public void DoOnConfirm()
    {
        switch (dungeonStates)
        {
            case DungeonStates.Normal:
            //interactplayer
                plyInter.TryToIntaract();
                break;
            case DungeonStates.OnMenuSelect:
                break;
            case DungeonStates.OnPause:
                break;
            case DungeonStates.cinematic:
                break;
            case DungeonStates.OnDialogue:
                //nextdialogue
                dialogues.NextDialogueLine();
                break;
            case DungeonStates:
                tuto.NextThing();
                break;
        }
    }
    void FixedUpdate()
    {
        switch(dungeonStates){
            case DungeonStates.Normal:
                playerMv.speed = 7;
                MenuCanvasDungeon.canOpenMenu = true;
                break;
            case DungeonStates.OnMenuSelect:
                playerMv.speed = 0;
                MenuCanvasDungeon.canOpenMenu = true;
                break;
            case DungeonStates.OnPause:
                playerMv.speed = 0;
                MenuCanvasDungeon.canOpenMenu = false;
                break;
            case DungeonStates.cinematic:
                playerMv.speed = 0;
                MenuCanvasDungeon.canOpenMenu = false;
                break;
            case DungeonStates.OnDialogue:
                playerMv.speed = 0;
                MenuCanvasDungeon.canOpenMenu = false;
                break;
            case DungeonStates.OnTutorial:
                playerMv.speed = 0;
                MenuCanvasDungeon.canOpenMenu = false;
                break;
        }
    }
    public void ChangeToNormal()
    {
        dungeonStates = DungeonStates.Normal;
        //apagar todos los canvas
    }
    public void ChangeToOnMenuSelect()
    {
        //activar el panel

    }
    public void AlternatePause()
    {
        if(dungeonStates != DungeonStates.OnPause)
        {
            Time.timeScale = 0;
            //open menu de pausa
        }
        else
        {
            ChangeToNormal();
            Time.timeScale = 1;
        }
    }
    public void CheckDoors(){
        if(!Door1)
        {
            doorsList[0].SetActive(false);
            ButtonsList[0].GetComponentInChildren<SpriteRenderer>().color = Color.grey;
            ButtonsList[0].GetComponent<CaseIntaruactable>().enabled = false;
        }
        if(!Door2)
        {
            doorsList[1].SetActive(false);
            ButtonsList[1].GetComponentInChildren<SpriteRenderer>().color = Color.grey;
            ButtonsList[1].GetComponent<CaseIntaruactable>().enabled = false;
        }
    }
    void TheDialogueFinished(int id, bool doSomethingAtEnd)
    {
        ChangeToNormal();
    }
}
[Serializable]
public enum DungeonStates
{
    Normal,
    OnMenuSelect,
    OnPause,
    cinematic,
    OnDialogue,
    OnTutorial
}
