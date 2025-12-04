using TMPro;
using UnityEngine;

public class textoStatico : MonoBehaviour
{
    public static string textoGlobal = "";
    public TextMeshProUGUI textoUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textoUI.text = textoGlobal;
    }
}
