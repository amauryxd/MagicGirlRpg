using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance { get; private set;}
    public EventSystem eventSystem;
    public DungeonStates dungeonStates;

    void Awake()
    {
        Instance = this;
    }

    public void DoOnConfirm()
    {
        switch (dungeonStates)
        {
            case DungeonStates.Normal:
                break;
            case DungeonStates.OnMenuSelect:
                break;
            case DungeonStates.OnPause:
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
}
[Serializable]
public enum DungeonStates
{
    Normal,
    OnMenuSelect,
    OnPause
}
