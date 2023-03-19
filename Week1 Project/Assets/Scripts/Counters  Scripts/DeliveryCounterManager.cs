using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounterManager : BaseCounter
{
    public static DeliveryCounterManager instance { get; private set; }

    void Awake()
    {
        instance = this;    
    }

    public override void Interaction(PlayerManager player)
    {
        if (player.HasKitchenIngredient())
        {
            if (player.GetKitchenIngredient().TryGetPlate(out PlateKitchenIngredient plateKitchenIngredient))
            {
                DeliveryManager.instance.DeliveryRecipe(plateKitchenIngredient);

                player.GetKitchenIngredient().DestroyIngredient();
            }     
        }
    }
}
