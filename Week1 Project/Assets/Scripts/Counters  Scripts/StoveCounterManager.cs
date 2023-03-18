using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterManager : BaseCounter
{
    [SerializeField] FryingRecipeSO[] fryingRecipeSOArray;

    float fryingTimer;

    void Update()
    {
        if (HasKitchenIngredient())
        {
            fryingTimer += Time.deltaTime;
            FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenIngredient().GetKitchenIngredientSO());
            if (fryingTimer > fryingRecipeSO.maximumFryingTime)
            {
                fryingTimer = 0f;
                Debug.Log("Fried!");
                GetKitchenIngredient().DestroyIngredient();

                KitchenIngredient.SpawnKitchenIngredient(fryingRecipeSO.output, this);
            }
            Debug.Log(fryingTimer);
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

            }
            else
            {
                GetKitchenIngredient().SetKitchenIngredientParent(player);
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
}
