using UnityEngine;

public class OnStayEffect : MonoBehaviour
{
    private bool hasExited;
    public float scaleToSum = 1f;
    public float smoothTime = 0.5f;
    private float referenceSpeed;
    public Vector2 initialScale;
    private Vector2 changedScale;
    void Start()
    {
        initialScale = transform.localScale;
        changedScale = transform.localScale;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Movement>(out Movement movement))
        {
            hasExited = false;
            changedScale = new Vector2(Mathf.SmoothDamp(changedScale.x, initialScale.x + scaleToSum, ref referenceSpeed, smoothTime), Mathf.SmoothDamp(changedScale.y, initialScale.y + scaleToSum, ref referenceSpeed, smoothTime));
            transform.localScale = changedScale;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Movement>(out Movement movement))
        {
            hasExited = true;
        }
    }
    void FixedUpdate()
    {
        if (hasExited)
        {
            changedScale = new Vector2(Mathf.SmoothDamp(changedScale.x, initialScale.x, ref referenceSpeed, smoothTime), Mathf.SmoothDamp(changedScale.y, initialScale.y, ref referenceSpeed, smoothTime));
            transform.localScale = changedScale;
        }
    }
}
