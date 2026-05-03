using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : InputHandler
{
    [SerializeField] public float speed;
    void FixedUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        if (!(controllerInput == Vector2.zero))
        {
            transform.position += new Vector3(controllerInput.x, controllerInput.y, 0)*Time.deltaTime*speed;
        }
    }
}
