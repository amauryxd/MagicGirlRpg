using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    protected Vector2 controllerInput;
    protected float fightMove;
    protected bool onConfirm;
    protected bool onNegate;
    public void OnMove(InputAction.CallbackContext context)
    {
        controllerInput = context.action.ReadValue<Vector2>();
    }
    public void OnMoveFight(InputAction.CallbackContext context)
    {
       fightMove = context.action.ReadValue<float>();
    }
    public void OnConfirm(InputAction.CallbackContext context)
    {
        onConfirm = context.performed;
    }
    public void OnNegate(InputAction.CallbackContext context)
    {
        onNegate = context.performed;
    }
}
