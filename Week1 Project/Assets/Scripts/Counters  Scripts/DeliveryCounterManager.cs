using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounterManager : BaseCounter
{
    public override void Interaction(PlayerManager player)
    {
        if (player.HasKitchenIngredient())
        {
            if (player.GetKitchenIngredient().TryGetPlate(out PlateKitchenIngredient plateKitchenIngredient))
            {
                player.GetKitchenIngredient().DestroyIngredient();
            }     
        }
    }
}
