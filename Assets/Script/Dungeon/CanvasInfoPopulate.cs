using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfoPopulate : MonoBehaviour
{
    public PlayerStatsSOB plyStats;
    public Image plySprite;
    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI nivelText;
    public TextMeshProUGUI vidaText;
    public TextMeshProUGUI ataqueText;
    public TextMeshProUGUI defensaText;
    public TextMeshProUGUI driveText;
    public void PopulateInfoCanvas()
    {
        plySprite.sprite = plyStats.plyImage;
        nombreText.text = plyStats.plyName;
        nivelText.text = "Nivel: " + plyStats.playerLvl.ToString();
        vidaText.text = "Vida: " + plyStats.playerCurrentHealth.ToString();
        ataqueText.text = "Ataque: " + plyStats.playerCurrentAtaque.ToString();
        defensaText.text = "Defensa: " + plyStats.playerCurrentDefensa.ToString();
        driveText.text = "Drive: " + plyStats.playerDrive.ToString();

    }
}
