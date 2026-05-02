using UnityEngine;
using UnityEngine.Events;

public class CaseIntaruactable : MonoBehaviour
{
    public UnityEvent whenIntaract;
    public void GetInteracted()
    {
        if (whenIntaract != null)
        {
            whenIntaract.Invoke();
            Debug.Log("tratando de interactuar");
        }
         else
        {
            Debug.Log("No hay nada asignado");
        }
    }
}
