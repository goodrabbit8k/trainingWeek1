using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounterManager : BaseCounter
{

    public static event EventHandler OnAnyIngredientTrashed;

    new public static void ResetStaticData()
    {
        OnAnyIngredientTrashed = null;
    }


    public override void Interaction(PlayerManager player)
    {
        if (player.HasKitchenIngredient())
        {
            player.GetKitchenIngredient().DestroyIngredient();

            OnAnyIngredientTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}
