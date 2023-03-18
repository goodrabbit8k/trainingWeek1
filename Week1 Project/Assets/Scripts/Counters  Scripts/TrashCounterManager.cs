using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounterManager : BaseCounter
{
    public override void Interaction(PlayerManager player)
    {
        if (player.HasKitchenIngredient())
        {
            player.GetKitchenIngredient().DestroyIngredient();
        }
    }
}
