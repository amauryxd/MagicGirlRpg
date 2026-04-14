using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NuevoJuegoManagment : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject nuevoJuegoButton;
    public GameObject noButton;
    public Animator anim;
    void OnEnable()
    {
        eventSystem.SetSelectedGameObject(noButton);
    }
    public void DesactivarEsto()
    {
        anim.SetTrigger("Desactivar");
    }
    public void loDeAnimConectar()
    {
        eventSystem.SetSelectedGameObject(nuevoJuegoButton);
        gameObject.SetActive(false);
    }
    public void OnClickSi()
    {
        SceneManager.LoadScene("RealWorld");
    }
}
