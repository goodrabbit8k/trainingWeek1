using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenIngredient : MonoBehaviour
{
    [SerializeField] KitchenIngredientSO kitchenIngredientSO;

    IKitchenIngredientParent kitchenIngredientParent;

    public KitchenIngredientSO GetKitchenIngredientSO()
    {
        return kitchenIngredientSO;
    }

    public void SetKitchenIngredientParent(IKitchenIngredientParent kitchenIngredientParent)
    {
        if (this.kitchenIngredientParent != null)
        {
            this.kitchenIngredientParent.ClearKitchenIngredient();
        }

        this.kitchenIngredientParent = kitchenIngredientParent;
        kitchenIngredientParent.SetKitchenIngredient(this);

        transform.parent = kitchenIngredientParent.GetKitchenIngredientFollowSpawnPoint();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenIngredientParent GetKitchenIngredientParent()
    {
        return kitchenIngredientParent;
    }
}
