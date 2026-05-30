using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GoBackInput : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.ctrlKey.isPressed && Keyboard.current.rKey.isPressed)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
