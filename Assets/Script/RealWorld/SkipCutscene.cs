using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipCutscene : InputHandler
{
    public Image imageToReveal;
    public TextMeshProUGUI textToReveal;
    public float revealSpeed = 0.5f;   
    public float requiredHoldTime = 3f;
    public string nextSceneName = "Dungeon";
    public float holdTime = 0;
    void Update()
    {
        if (onConfirm)
        {
            holdTime += Time.deltaTime;

            Color imgColor = imageToReveal.color;
            imgColor.a = Mathf.Clamp01(imgColor.a + revealSpeed * Time.deltaTime);
            imageToReveal.color = imgColor;

            Color txtColor = textToReveal.color;
            txtColor.a = Mathf.Clamp01(txtColor.a + revealSpeed * Time.deltaTime);
            textToReveal.color = txtColor;

            if (holdTime >= requiredHoldTime)
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
        else
        {
            holdTime = 0;
            imageToReveal.color = new Color(imageToReveal.color.r, imageToReveal.color.g, imageToReveal.color.b, 0f);
            textToReveal.color = new Color(textToReveal.color.r, textToReveal.color.g, textToReveal.color.b, 0f);
        }
    }
}
