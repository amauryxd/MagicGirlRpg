using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDieConector : MonoBehaviour
{
    public GameObject TextoArriva;
    public GameObject Botones;
    public void apagarCosas()
    {
        TextoArriva.SetActive(false);
        Botones.SetActive(false);
    }  
    public void CambiarScena()
    {
        SceneManager.LoadScene("HisTell2");
    }
}
