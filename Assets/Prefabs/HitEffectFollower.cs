using UnityEngine;

public class HitEffectFollower : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float velocity;
    void FixedUpdate()
    {
        Follow();
    }
    public void setPoints(Transform start, Transform end, float vel)
    {
        startPoint = start;
        endPoint = end;
        velocity = vel;
    }
    public void Follow()
    {
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, velocity);
    }
}
