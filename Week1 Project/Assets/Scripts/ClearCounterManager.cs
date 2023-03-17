using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounterManager : BaseCounter
{
    [SerializeField] KitchenIngredientSO kitchenIngredientSO;

    public override void Interaction(PlayerManager player)
    {
        if (!HasKitchenIngredient())
        {
            if (player.HasKitchenIngredient())
            {
                player.GetKitchenIngredient().SetKitchenIngredientParent(this);
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
}
