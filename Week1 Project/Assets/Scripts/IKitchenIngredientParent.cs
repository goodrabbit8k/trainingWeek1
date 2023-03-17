using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenIngredientParent
{
    public Transform GetKitchenIngredientFollowSpawnPoint();

    public void SetKitchenIngredient(KitchenIngredient kitchenIngredient);

    public KitchenIngredient GetKitchenIngredient();

    public void ClearKitchenIngredient();

    public bool HasKitchenIngredient();
}
