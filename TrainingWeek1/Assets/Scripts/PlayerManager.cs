using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;

    PlayerInput gameInput;

    bool isMoving = false;

    void Start()
    {
        gameInput = GameObject.Find("GameInput").GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 inputVector = gameInput.GetMovement();
        Vector3 movementDir = new Vector3(inputVector.x, 0, inputVector.y);
        isMoving = movementDir != Vector3.zero;
        float rotationSpeed = 5.0f;

        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float playerDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, movementDir, playerDistance);

        if (!canMove)
        {
            Vector3 movementDirX = new Vector3(movementDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, movementDirX, playerDistance);

            if (canMove)
            {
                movementDir = movementDirX;
            }
            else
            {
                Vector3 movementDirZ = new Vector3(0, 0, movementDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, movementDirZ, playerDistance);

                if (canMove)
                {
                    movementDir = movementDirZ;
                }
                else
                {

                }
            }
        }
        

        if (canMove)
        {
            transform.position += movementDir * playerDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, movementDir, Time.deltaTime * rotationSpeed);
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
