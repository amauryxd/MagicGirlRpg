using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class NuevoJuegoManagment : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject nuevoJuegoButton;
    public GameObject noButton;
    public Animator anim;
    public List<Button> theOthers;
    void OnEnable()
    {
        eventSystem.SetSelectedGameObject(noButton);
        foreach (Button button in theOthers)
        {
            button.interactable = false;
        }
    }
    void OnDisable()
    {
        foreach (Button button in theOthers)
        {
            button.interactable = true;
        }
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
