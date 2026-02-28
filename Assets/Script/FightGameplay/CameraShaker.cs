using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance;
    private float shakeAmount = 0.02f;
    private Vector3 initialPos;
    private bool canShake = false;
    void Awake()
    {
        initialPos = transform.position;
        Instance = this;
    }
    void Start()
    {
        canShake = false;
    }

    void Update()
    {
        if (canShake)
            transform.position = initialPos + Random.insideUnitSphere * shakeAmount;
    }

    private IEnumerator CanStartShaking(float shakeTime)
    {
        canShake = true;
        yield return new WaitForSeconds(shakeTime);
        canShake = false;
        transform.position = initialPos;
    }
    public void ShakeThisCamera(float shakeTime, float amountShake)
    {
        shakeAmount = amountShake;
        StartCoroutine(CanStartShaking(shakeTime));
    }
}
