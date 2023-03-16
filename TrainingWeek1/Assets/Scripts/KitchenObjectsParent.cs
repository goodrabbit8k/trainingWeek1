using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface KitchenObjectsParent
{
    public Transform GetKitchenObjectFollowTransform();

    public KitchenObjects GetKitchenIngredient();

    public void ClearKitchenIngredient();

    public void SetKitchenIngredient(KitchenObjects kitchenObject);

    public bool HasKitchenIngredient();
}
