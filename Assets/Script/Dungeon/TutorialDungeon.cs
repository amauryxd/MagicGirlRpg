using System.Collections;
using UnityEngine;

public class TutorialDungeon : MonoBehaviour
{
    public GameObject SecondImage;
    public GameObject ThirdImage;
    public GameObject ForuthImage;
    public bool canPassNext= false;
    private void OnEnable()
    {
        StartCoroutine(ChangeThisState());
        StartCoroutine(CanPassChanger());
    }
    public void NextThing()
    {
        if(SecondImage.activeInHierarchy == false && canPassNext)
        {
            SecondImage.SetActive(true);
            canPassNext = false;
            StartCoroutine(CanPassChanger());
            return;
        }
        if(ThirdImage.activeInHierarchy == false && canPassNext)
        {
            ThirdImage.SetActive(true);
            canPassNext = false;
            StartCoroutine(CanPassChanger());
            return;
        }
        if(ForuthImage.activeInHierarchy == false && canPassNext)
        {
            ForuthImage.SetActive(true);
            canPassNext = false;
            StartCoroutine(CanPassChanger());
            return;
        }
        if (canPassNext)
        {
            DungeonManager.Instance.dungeonStates = DungeonStates.Normal;
            gameObject.SetActive(false);
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
        canPassNext = true;
    }
}
