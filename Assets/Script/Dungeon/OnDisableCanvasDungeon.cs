using UnityEngine;

public class OnDisableCanvasDungeon : MonoBehaviour
{
    public GameObject canvasToDisable;
    public GameObject toAtivate;
    void OnDisable()
    {
        canvasToDisable.SetActive(false);
        toAtivate.SetActive(true);
    }
}
