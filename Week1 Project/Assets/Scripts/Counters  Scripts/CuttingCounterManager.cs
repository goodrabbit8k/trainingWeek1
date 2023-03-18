using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterManager : BaseCounter, IHasProcess
{

    [SerializeField] CuttingRecipeSO[] cuttingRecipeSOArray;

    public event EventHandler<IHasProcess.onProcessChangeEventArgs> onProcessChange;
    public event EventHandler onCutting;

    float cuttingProcess;

    public override void Interaction(PlayerManager player)
    {
        if (!HasKitchenIngredient())
        {
            if (player.HasKitchenIngredient())
            {
                if (HasRecipeWithInput(player.GetKitchenIngredient().GetKitchenIngredientSO()))
                {
                    player.GetKitchenIngredient().SetKitchenIngredientParent(this);
                    cuttingProcess = 0;

                    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenIngredient().GetKitchenIngredientSO());
                    onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = cuttingProcess / cuttingRecipeSO.maximumCuttingProcess });
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

    public override void InteractionAlternate(PlayerManager player)
    {
        if (HasKitchenIngredient() && HasRecipeWithInput(GetKitchenIngredient().GetKitchenIngredientSO())) 
        {
            cuttingProcess++;
            onCutting?.Invoke(this, EventArgs.Empty);
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenIngredient().GetKitchenIngredientSO());

            onProcessChange?.Invoke(this, new IHasProcess.onProcessChangeEventArgs { processNormalized = cuttingProcess / cuttingRecipeSO.maximumCuttingProcess });

            if (cuttingProcess >= cuttingRecipeSO.maximumCuttingProcess)
            {
                KitchenIngredientSO outputKitchenIngredientSO = GetOutputForInput(GetKitchenIngredient().GetKitchenIngredientSO());
                GetKitchenIngredient().DestroyIngredient();

                KitchenIngredient.SpawnKitchenIngredient(outputKitchenIngredientSO, this);
            }
        }
    }

    bool HasRecipeWithInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenIngredientSO);
        return cuttingRecipeSO != null;
    }

    KitchenIngredientSO GetOutputForInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenIngredientSO);

        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenIngredientSO inputKitchenIngredientSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenIngredientSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }
}
