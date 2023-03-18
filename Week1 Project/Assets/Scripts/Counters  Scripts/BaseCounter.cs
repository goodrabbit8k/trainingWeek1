using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenIngredientParent
{
    [SerializeField] GameObject spawnPoint;

    KitchenIngredient kitchenIngredient;

    public virtual void Interaction(PlayerManager player)
    {
        Debug.Log("BaseCounter.Interaction();");
    }

    public virtual void InteractionAlternate(PlayerManager player)
    {
        //Debug.Log("BaseCounter.InteractionAlternate();");
    }

    public Transform GetKitchenIngredientFollowSpawnPoint()
    {
        return spawnPoint.transform;
    }

    public void SetKitchenIngredient(KitchenIngredient kitchenIngredient)
    {
        this.kitchenIngredient = kitchenIngredient;
    }

    public KitchenIngredient GetKitchenIngredient()
    {
        return kitchenIngredient;
    }

    public void ClearKitchenIngredient()
    {
        kitchenIngredient = null;
    }

    public bool HasKitchenIngredient()
    {
        return kitchenIngredient != null;
    }
}
