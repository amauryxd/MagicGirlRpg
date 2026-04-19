using UnityEngine;
using UnityEngine.UI;

public class CanvaOnDesactivate : MonoBehaviour
{
    public GameObject phoneFirstCanvas;
    public GameObject phoneContactsCanvas;

    void OnDisable()
    {
        phoneFirstCanvas.SetActive(true);
        phoneContactsCanvas.SetActive(false);
    }
}
