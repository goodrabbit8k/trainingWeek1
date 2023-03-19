using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IKitchenIngredientParent
{
    public static PlayerManager Instance { get; private set; }

    public event EventHandler OnPickedSomething;
    public event EventHandler <OnSelectedCounterEventArgs> OnSelectedCounter;
    public class OnSelectedCounterEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    [SerializeField] PlayerInput playerInput;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] LayerMask countersLayerMask;
    [SerializeField] GameObject holdPoint;

    BaseCounter selectedCounter;
    KitchenIngredient kitchenIngredient;
    Vector3 lastInteractDirection;
    bool isMoving;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Too many");
        }

        Instance = this;
    }

    void Start()
    {
        playerInput.OnInteractionAction += PlayerInput_InteractionAction;
        playerInput.OnInteractionAlternateAction += PlayerInput_OnInteractionAlternateAction;
    }

    private void PlayerInput_OnInteractionAlternateAction(object sender, EventArgs e)
    {
        if (!GameManager.instance.IsGamePlaying()) return;

        if (selectedCounter != null)
        {
            selectedCounter.InteractionAlternate(this);
        }
    }

    private void PlayerInput_InteractionAction(object sender, System.EventArgs e)
    {
        if (!GameManager.instance.IsGamePlaying()) return;

        if (selectedCounter != null)
        {
            selectedCounter.Interaction(this);
        }
    }

    void Update()
    {
        ManagePlayerMovement();
        ManagePlayerInteraction();
    }

    public bool PlayerMovingCondition()
    {
        return isMoving;
    }

    void ManagePlayerInteraction()
    {
        Vector3 movementDirection = new Vector3(playerInput.GetMovementInput().x, 0f, playerInput.GetMovementInput().y);

        if (movementDirection != Vector3.zero)
        {
            lastInteractDirection = movementDirection;
        }

        float interactDistance = 1f;
        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    void ManagePlayerMovement()
    {
        Vector3 movementDirection = new Vector3(playerInput.GetMovementInput().x, 0f, playerInput.GetMovementInput().y);
        float playerSize = 0.1f;
        float playerHeight = 2f;
        float movementDistance = movementSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, movementDirection, movementDistance);

        if (!canMove)
        {
            Vector3 movementDirectionX = new Vector3(movementDirection.x, 0f, 0f).normalized;
            canMove = movementDirection.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, movementDirectionX, movementDistance);

            if (canMove)
            {
                movementDirection = movementDirectionX;
            }
            else
            {
                Vector3 movementDirectionY = new Vector3(0f, 0f, movementDirection.z).normalized;
                canMove = movementDirection.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, movementDirectionY, movementDistance);

                if (canMove)
                {
                    movementDirection = movementDirectionY;
                }
                else
                {

                }
            }
        }

        if (canMove)
        {
            transform.position += movementDirection * movementDistance;
        }

        isMoving = movementDirection != Vector3.zero;

        float rotationSpeed = 5f;
        transform.forward = Vector3.Slerp(transform.forward, movementDirection, rotationSpeed * Time.deltaTime);
    }

    public void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounter?.Invoke(this, new OnSelectedCounterEventArgs { selectedCounter = selectedCounter });
    }

    public Transform GetKitchenIngredientFollowSpawnPoint()
    {
        return holdPoint.transform;
    }

    public void SetKitchenIngredient(KitchenIngredient kitchenIngredient)
    {
        this.kitchenIngredient = kitchenIngredient;

        if (kitchenIngredient != null)
        {
            OnPickedSomething?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenIngredient GetKitchenIngredient()
    {
        return kitchenIngredient;
    }

    public void ClearKitchenIngredient()
    {
        kitchenIngredient = null;
    }

    public bool HasKitchenIngredient()
    {
        return kitchenIngredient != null;
    }
}
