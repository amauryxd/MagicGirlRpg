using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public MenuState currentMenuState;
    void OnEnable()
    {
        currentMenuState = MenuState.Start;
    }
    public void OnClickChanger(int menuState)
    {
        currentMenuState = menuState switch
        {
            0 => MenuState.Start,
            1 => MenuState.Continuar,
            2 => MenuState.NuevoJuego,
            3 => MenuState.Opciones,
            4 => MenuState.Creditos,
            5 => MenuState.salir,
            _ => currentMenuState
        };
        changeMenu();
    }
#region Menu States
    private void MenuStartState()
    {
        //activar la hoja
        //cambiar el cheider
        //desactivar los demas menus
        //cambiar como se ve el logo?
        //animacion de entrada de la hoja
    }
    private void MenuContinuarState()
    {
        //activar los 4 slots de guardado
        //POST> llamar a la funcion de cargar partida
        //desactivar los demas menus
        //cambiar cheider > comprobar si se puede hacer la animacione de la hoja
        //al regresar o picarle al mismo hacer la animacion de inicio
    }
    private void MenuNuevoJuegoState()
    {
        //difumniar fondo
        //activar panel de juego nuevo
        //desactivar los demas menus
        //regresar a estado start si se cancela
        //al regresar o picarle al mismo hacer la animacion de inicio
    }
    private void MenuOpcionesState()
    {
        //activar panel de opciones
        //desactivar los demas menus
        //comprobar si se puede hacer la animacione de la hoja > cambiar cheider
        //guardar cambios al salir
        //al regresar o picarle al mismo hacer la animacion de inicio
    }
    private void MenuCreditosState()
    {
        //activar panel de creditos
        //desactivar los demas menus
        //comprobar si se puede hacer la animacione de la hoja > cambiar cheider
        //al regresar o picarle al mismo hacer la animacion de inicio
    }
    private void changeMenu()
    {
        switch (currentMenuState)
        {
            case MenuState.Start:
            MenuStartState();
                break;
            case MenuState.Continuar:
            MenuContinuarState();
                break;
            case MenuState.NuevoJuego:
            MenuNuevoJuegoState();
                break;
            case MenuState.Opciones:
            MenuOpcionesState();
                break;
            case MenuState.Creditos:
            MenuCreditosState();
                break;
            case MenuState.salir:
                Application.Quit();
                break;
            default:
                break;
        }
    }
#endregion
}

public enum MenuState
{
    Start,
    Continuar,
    NuevoJuego,
    Opciones,
    Creditos,
    salir
}