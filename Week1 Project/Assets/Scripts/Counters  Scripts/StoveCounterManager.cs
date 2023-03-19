using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterManager : BaseCounter, IHasProcess
{
    public event EventHandler<IHasProcess.onProcessChangeEventArgs> onProcessChange;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }

    public enum State
    {
        Idle, Frying, Fried, Burned,
    }

    [SerializeField] FryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] BurningRecipeSO[] burningRecipeSOArray;

    FryingRecipeSO fryingRecipeSO;
    BurningRecipeSO burningRecipeSO;
    State state;
    float fryingTimer;
    float burningTimer;

    void Start()
    {
        state = State.Idle;
    }

    void Update()
    {
        if (HasKitchenIngredient())
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;

                    onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = fryingTimer / fryingRecipeSO.maximumFryingTime });

                    if (fryingTimer > fryingRecipeSO.maximumFryingTime)
                    {
                        GetKitchenIngredient().DestroyIngredient();

                        KitchenIngredient.SpawnKitchenIngredient(fryingRecipeSO.output, this);

                        state = State.Fried;
                        burningTimer = 0f;

                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenIngredient().GetKitchenIngredientSO());

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs {state = state });
                    }
                    break;
                case State.Fried:
                    burningTimer += Time.deltaTime;

                    onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = burningTimer / burningRecipeSO.maximumBurningTime });

                    if (burningTimer > burningRecipeSO.maximumBurningTime)
                    {
                        GetKitchenIngredient().DestroyIngredient();

                        KitchenIngredient.SpawnKitchenIngredient(burningRecipeSO.output, this);

                        state = State.Burned;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });
                        onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = 0f });
                    }
                    break;
                case State.Burned:
                    break;
            }
        }
    }

    public override void Interaction(PlayerManager player)
    {
        if (!HasKitchenIngredient())
        {
            if (player.HasKitchenIngredient())
            {
                if (HasRecipeWithInput(player.GetKitchenIngredient().GetKitchenIngredientSO()))
                {
                    player.GetKitchenIngredient().SetKitchenIngredientParent(this);

                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenIngredient().GetKitchenIngredientSO());

                    state = State.Frying;
                    fryingTimer = 0f;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });
                }
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenIngredient())
            {
                if (player.GetKitchenIngredient().TryGetPlate(out PlateKitchenIngredient plateKitchenIngredient))
                {
                    if (plateKitchenIngredient.TryAddIngredient(GetKitchenIngredient().GetKitchenIngredientSO()))
                    {
                        GetKitchenIngredient().DestroyIngredient();

                        state = State.Idle;

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });

                        onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = 0f });
                    }
                }
            }
            else
            {
                GetKitchenIngredient().SetKitchenIngredientParent(player);

                state = State.Idle;

                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs { state = state });

                onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = 0f });
            }
        }
    }

    bool HasRecipeWithInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenIngredientSO);
        return fryingRecipeSO != null;
    }

    KitchenIngredientSO GetOutputForInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenIngredientSO);

        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    FryingRecipeSO GetFryingRecipeSOWithInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenIngredientSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }

    BurningRecipeSO GetBurningRecipeSOWithInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        foreach (BurningRecipeSO burningRecipeSO in burningRecipeSOArray)
        {
            if (burningRecipeSO.input == inputKitchenIngredientSO)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
