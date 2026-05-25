using System.Collections;
using UnityEngine;

public class TutorialDungeon : MonoBehaviour
{
    public GameObject FirstObject;
    public GameObject SecondImage;
    public GameObject ThirdImage;
    public GameObject ForuthImage;
    public bool canPassNext= false;
    public GameObject AAButon;
    public int CountWich;
    private void OnEnable()
    {
        StartCoroutine(ChangeThisState());
        StartCoroutine(CanPassChanger());
        CountWich = 0;
    }
    public void NextThing()
    {
        if (canPassNext)
        {
            switch (CountWich)
            {
            case 0:
                FirstObject.SetActive(false);
                SecondImage.SetActive(true);
                AAButon.SetActive(false);
                canPassNext = false;
                StartCoroutine(CanPassChanger());
                CountWich++;
                break;
            case 1:
                SecondImage.SetActive(false);
                ThirdImage.SetActive(true);
                AAButon.SetActive(false);
                canPassNext = false;
                StartCoroutine(CanPassChanger());
                CountWich++;
                break;
            case 2:
                ThirdImage.SetActive(false);
                ForuthImage.SetActive(true);
                AAButon.SetActive(false);
                canPassNext = false;
                StartCoroutine(CanPassChanger());
                CountWich++;
                break;
            case 3:
                DungeonManager.Instance.dungeonStates = DungeonStates.Normal;
                gameObject.SetActive(false);
                break;
            }
        }

    }
    public IEnumerator ChangeThisState()
    {
        yield return new WaitForSeconds(0.2f);
        DungeonManager.Instance.dungeonStates = DungeonStates.OnTutorial;
    }
    public IEnumerator CanPassChanger()
    {
        yield return new WaitForSeconds(1.5f);
        AAButon.SetActive(true);
        canPassNext = true;
    }
}
