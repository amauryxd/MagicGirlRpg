using UnityEngine;

public class LittleMovement : MonoBehaviour
{
    public float moveRange = 0.1f; 
    public float speed = 1f;

    void FixedUpdate()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-moveRange, moveRange),
            0,
            Random.Range(-moveRange, moveRange)
        );

        transform.position = Vector3.Lerp(
            transform.position,
            transform.position + randomOffset,
            Time.deltaTime * speed
        );
    }

}
