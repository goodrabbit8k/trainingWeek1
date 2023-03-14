using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputSystem playerInputSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();
    }

    public Vector2 GetMovement()
    {
        Vector2 movementInput = playerInputSystem.Player.Move.ReadValue<Vector2>();

        movementInput = movementInput.normalized;

        return movementInput;
    }
}
