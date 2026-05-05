using UnityEngine;
using UnityEngine.EventSystems;

public class MenuCanvasDungeon : MonoBehaviour
{
    public GameObject menuCanvas;
    public EventSystem eventSystem;
    public GameObject firstSelectedButton;
    private bool isMenuOpen = false;
    public void OpenMenuDungeon()
    {
        if(isMenuOpen)
        {
            menuCanvas.SetActive(false);
            isMenuOpen = false;
        }
        else
        {
            menuCanvas.SetActive(true);
            eventSystem.SetSelectedGameObject(firstSelectedButton);
            isMenuOpen = true;
        }
    }
}
