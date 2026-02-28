using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public float amplitude = 1.0f;   
    public float frequency = 1.0f;  
    public Vector3 axisMultiplier = new Vector3(1, 1, 0); 

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float time = Time.time * frequency;

        float x = (Mathf.PerlinNoise(time, 0) - 0.5f) * 2 * amplitude * axisMultiplier.x;
        float y = (Mathf.PerlinNoise(0, time) - 0.5f) * 2 * amplitude * axisMultiplier.y;
        float z = (Mathf.PerlinNoise(time, time) - 0.5f) * 2 * amplitude * axisMultiplier.z;

        transform.position = startPos + new Vector3(x, y, z);
    }


}
