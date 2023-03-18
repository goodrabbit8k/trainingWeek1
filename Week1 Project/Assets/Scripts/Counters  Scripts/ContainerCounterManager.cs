using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterManager : BaseCounter
{
    [SerializeField] KitchenIngredientSO kitchenIngredientSO;

    public event EventHandler onPlayerHoldingIngredient;

    public override void Interaction(PlayerManager player)
    {
        if (!player.HasKitchenIngredient())
        {
            KitchenIngredient.SpawnKitchenIngredient(kitchenIngredientSO, player);

            onPlayerHoldingIngredient.Invoke(this, EventArgs.Empty);
        }
    }
}
