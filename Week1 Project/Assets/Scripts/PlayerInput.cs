using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputSystem playerInputAction;

    public event EventHandler OnInteractionAction;
    public event EventHandler OnInteractionAlternateAction;

    void Awake()
    {
        playerInputAction = new PlayerInputSystem();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;
        playerInputAction.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractionAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractionAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementInput()
    {
        Vector2 movementInput = playerInputAction.Player.Move.ReadValue<Vector2>();

        movementInput = movementInput.normalized;

        return movementInput;
    }
}
