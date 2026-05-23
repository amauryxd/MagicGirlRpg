using UnityEngine;
using System.Collections;

public class TutorialEnabler : MonoBehaviour
{
    public bool canDesactivate;
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
        canDesactivate = true;
    }
}
