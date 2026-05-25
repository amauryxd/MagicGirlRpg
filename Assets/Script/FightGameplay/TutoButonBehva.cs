using System.Collections;
using UnityEngine;

public class TutoButonBehva : MonoBehaviour
{
    public GameObject FirstObject;
    public GameObject nextImage;
    public GameObject toDesactivate;
    public int count;
    public bool canChange;
    public GameObject AAButon;
    private void Start()
    {
        count = 0;
        canChange = false;
    }
    public void DoSomethingThisButton()
    {
        Debug.Log("ayishbdas");
        if(count == 0)
        {
            FirstObject.SetActive(false);
            nextImage.SetActive(true);
            AAButon.SetActive(false);
            count++;
            StartCoroutine(WaitALittle());
        }
        if(count == 1 && canChange)
        {
            toDesactivate.SetActive(false);
        }
    }
    public IEnumerator WaitALittle()
    {
        yield return new WaitForSeconds(1f);
        AAButon.SetActive(true);
        canChange = true;
    }
}
