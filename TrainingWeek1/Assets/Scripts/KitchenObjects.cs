using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField] KitchenScriptableObject kitchenScriptableObject;

    KitchenObjectsParent kitchenObjectsParent;

    public KitchenScriptableObject GetKitchenScriptableObject()
    {
        return kitchenScriptableObject;
    }

    public void SetKitchenObjectsParent(KitchenObjectsParent kitchenObjectParent)
    {
        if (this.kitchenObjectsParent != null)
        {
            this.kitchenObjectsParent.ClearKitchenIngredient();
        }

        if (kitchenObjectParent.HasKitchenIngredient())
        {
            Debug.LogError("Counter already use");
        }

        kitchenObjectParent.SetKitchenIngredient(this);

        this.kitchenObjectsParent = kitchenObjectParent;
        transform.parent = kitchenObjectsParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public KitchenObjectsParent GetKitchenObjectsParent()
    {
        return kitchenObjectsParent;
    }
}
