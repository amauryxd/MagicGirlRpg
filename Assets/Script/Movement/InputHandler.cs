using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 controllerInput;
    public float fightMove;
    public bool onConfirm;
    public bool onNegate;
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
        if (context.performed) ConfirmAction();
    }
    public void OnNegate(InputAction.CallbackContext context)
    {
        onNegate = context.performed;
        if (context.performed) NegateAction();
    }
    public virtual void ConfirmAction() { }
    public virtual void NegateAction() {}
}
