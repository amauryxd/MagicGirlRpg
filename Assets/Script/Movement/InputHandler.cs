using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    protected Vector2 controllerInput;
    public void OnMove(InputAction.CallbackContext context)
    {
        controllerInput = context.action.ReadValue<Vector2>();
    }
}
