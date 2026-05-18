using UnityEngine;

public class OnDisableCanvasDungeon : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject toAtivate;
    public GameObject anotherToDesactivate;
    void OnDisable()
    {
        canvasToDisable.SetActive(false);
        toAtivate.SetActive(true);
        anotherToDesactivate.SetActive(false);
    }
}
