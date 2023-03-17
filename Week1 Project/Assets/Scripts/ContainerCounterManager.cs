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
            Transform kitchenIngredientSpawnPos = Instantiate(kitchenIngredientSO.prefab);
            kitchenIngredientSpawnPos.GetComponent<KitchenIngredient>().SetKitchenIngredientParent(player);

            onPlayerHoldingIngredient.Invoke(this, EventArgs.Empty);
        }
    }
}
