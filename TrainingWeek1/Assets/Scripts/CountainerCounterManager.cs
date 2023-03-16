using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountainerCounterManager : MonoBehaviour, KitchenObjectsParent
{
    [SerializeField] KitchenScriptableObject kitchenIngredientsSO;
    [SerializeField] GameObject spawnPos;

    KitchenObjects kitchenObjects;

    public void Interaction(PlayerManager player)
    {
        if (kitchenObjects == null)
        {
            Debug.Log("Interact");
            GameObject kitchenObjectTransform = Instantiate(kitchenIngredientsSO.ingredientPrefab, spawnPos.transform.position, kitchenIngredientsSO.ingredientPrefab.transform.rotation);
            kitchenObjectTransform.GetComponent<KitchenObjects>().SetKitchenObjectsParent(this);
        }
        else
        {
            kitchenObjects.SetKitchenObjectsParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return spawnPos.transform;
    }

    public KitchenObjects GetKitchenIngredient()
    {
        return kitchenObjects;
    }

    public void ClearKitchenIngredient()
    {
        kitchenObjects = null;
    }

    public void SetKitchenIngredient(KitchenObjects kitchenObject)
    {
        this.kitchenObjects = kitchenObject;
    }

    public bool HasKitchenIngredient()
    {
        return kitchenObjects != null;
    }
}
