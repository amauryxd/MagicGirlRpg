using UnityEngine;
using UnityEngine.EventSystems;

public class MenuCanvasDungeon : MonoBehaviour
{
    public GameObject menuCanvas;
    public EventSystem eventSystem;
    public GameObject firstSelectedButton;
    public static bool canOpenMenu = true;
    private bool isMenuOpen = false;
    public void OpenMenuDungeon()
    {
        if(isMenuOpen)
        {
            menuCanvas.SetActive(false);
            isMenuOpen = false;
            DungeonManager.Instance.dungeonStates = DungeonStates.Normal;
        }
        else
        {
            menuCanvas.SetActive(true);
            eventSystem.SetSelectedGameObject(firstSelectedButton);
            isMenuOpen = true;
            DungeonManager.Instance.dungeonStates = DungeonStates.OnMenuSelect;
        }
    }
}
