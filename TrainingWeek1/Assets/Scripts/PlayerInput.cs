using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event EventHandler interactionEvent;

    PlayerInputSystem playerInputSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();

        playerInputSystem.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        interactionEvent?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovement()
    {
        Vector2 movementInput = playerInputSystem.Player.Move.ReadValue<Vector2>();

        movementInput = movementInput.normalized;

        return movementInput;
    }
}
