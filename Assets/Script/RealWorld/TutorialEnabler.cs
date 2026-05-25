using UnityEngine;
using System.Collections;

public class TutorialEnabler : MonoBehaviour
{
    public bool canDesactivate;
    public GameObject AAAButon;
    void OnEnable()
    {
        canDesactivate = false;
        StartCoroutine(ItCanDes());
    }
    public IEnumerator ItCanDes()
    {
        yield return new WaitForSeconds(0.2f);
        RealWorldManager.Instance.currentState = RealWorldState.OnTutorial;
        yield return new WaitForSeconds(2f);
        AAAButon.SetActive(true);
        canDesactivate = true;
    }
}
