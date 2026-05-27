using System.Collections;
using UnityEngine;

public class TutoButonBehva : MonoBehaviour
{
    public GameObject FirstObject;
    public GameObject nextImage;
    public GameObject LastImage;
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
        
        if(count == 0)
        {
            FirstObject.SetActive(false);
            nextImage.SetActive(true);
            AAButon.SetActive(false);
            count++;
            StartCoroutine(WaitALittle());
            Debug.Log("ayishbdas");
        }
        if(count == 1 && canChange)
        {
            nextImage.SetActive(false);
            LastImage.SetActive(true);
            AAButon.SetActive(false);
            canChange = false;
            count++;
            StartCoroutine(WaitALittle()); Debug.Log("B");
        }
        if( count == 2 && canChange)
        {
            Debug.Log("c");
            toDesactivate.SetActive(false);
        }
    }
    public IEnumerator WaitALittle()
    {
        yield return new WaitForSeconds(1f);
        canChange = true;
        AAButon.SetActive(true);
    }
}
