using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounterManager : MonoBehaviour, IKitchenIngredientParent
{
    [SerializeField] KitchenIngredientSO kitchenIngredientSO;
    [SerializeField] GameObject spawnPoint;

    KitchenIngredient kitchenIngredient;

    public void Interaction(PlayerManager player)
    {
        if (kitchenIngredient == null)
        {
            Transform kitchenIngredientSpawnPos = Instantiate(kitchenIngredientSO.prefab, spawnPoint.transform);
            kitchenIngredientSpawnPos.GetComponent<KitchenIngredient>().SetKitchenIngredientParent(this);
        }
        else
        {
            kitchenIngredient.SetKitchenIngredientParent(player);
        }
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
