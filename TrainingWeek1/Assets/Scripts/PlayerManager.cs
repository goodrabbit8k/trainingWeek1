using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance { get; private set; }
    public event EventHandler <ChangeSelectedCounterEventArgs> ChangeSelectedCounterEvent;
    public class ChangeSelectedCounterEventArgs : EventArgs
    {
        public ClearCounterManager clearCounterSelect;
    }

    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] LayerMask clearCounterMask;

    PlayerInput gameInput;
    ClearCounterManager clearCounterSelect;

    Vector3 playerLastInteractDir;
    

    bool isMoving = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameInput = GameObject.Find("GameInput").GetComponent<PlayerInput>();

        gameInput.interactionEvent += GameInput_interactionEvent;
    }

    private void GameInput_interactionEvent(object sender, System.EventArgs e)
    {
        if (clearCounterSelect != null)
        {
            clearCounterSelect.Interact();
        }
    }

    void Update()
    {
        PlayerInteraction();
        PlayerMovement();
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    void PlayerInteraction()
    {
        Vector2 inputVector = gameInput.GetMovement();
        Vector3 movementDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float playerInteractDistance = 1f;

        if (movementDir != Vector3.zero)
        {
            playerLastInteractDir = movementDir;
        }

        if (Physics.Raycast(transform.position, playerLastInteractDir, out RaycastHit hitInfo, playerInteractDistance, clearCounterMask))
        {
            if (hitInfo.transform.TryGetComponent(out ClearCounterManager clearCounterManager))
            {
                if (clearCounterManager != clearCounterSelect)
                {
                    SelectedCounter(clearCounterManager);
                }
            }
            else
            {
                SelectedCounter(null);
            }
        }
        else
        {
            SelectedCounter(null);
        }

        Debug.Log(clearCounterSelect);
    }
    void PlayerMovement()
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
            }
        }

        if (canMove)
        {
            transform.position += movementDir * playerDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, movementDir, Time.deltaTime * rotationSpeed);
    }

    void SelectedCounter(ClearCounterManager clearCounterSelect)
    {
        this.clearCounterSelect = clearCounterSelect;

        ChangeSelectedCounterEvent?.Invoke(this, new ChangeSelectedCounterEventArgs { clearCounterSelect = clearCounterSelect });
    }
}
