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
                if (player.GetKitchenIngredient().TryGetPlate(out PlateKitchenIngredient plateKitchenIngredient))
                {
                    if (plateKitchenIngredient.TryAddIngredient(GetKitchenIngredient().GetKitchenIngredientSO()))
                    {
                        GetKitchenIngredient().DestroyIngredient();
                    }
                }
                else
                {
                    if (GetKitchenIngredient().TryGetPlate(out plateKitchenIngredient))
                    {
                        if (plateKitchenIngredient.TryAddIngredient(player.GetKitchenIngredient().GetKitchenIngredientSO()))
                        {
                            player.GetKitchenIngredient().DestroyIngredient();
                        }
                    }
                }
            }
            else
            {
                GetKitchenIngredient().SetKitchenIngredientParent(player);
            }
        }
    }
}
