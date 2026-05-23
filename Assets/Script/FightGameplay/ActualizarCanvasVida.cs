using UnityEngine;
using UnityEngine.UI;

public class ActualizarCanvasVida : MonoBehaviour
{
    public Slider vidaRef;
    public PlayerStatsSOB statsRef;

    private void Awake()
    {
        vidaRef.value = statsRef.playerCurrentHealth;
    }
}
