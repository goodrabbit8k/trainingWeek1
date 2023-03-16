using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounterManager : MonoBehaviour
{
    [SerializeField] KitchenScriptableObject kitchenIngredientsSO;
    [SerializeField] GameObject spawnPos;

    

    public void Interact()
    {
        Debug.Log("Interact");
        Instantiate(kitchenIngredientsSO.ingredientPrefab, spawnPos.transform.position, kitchenIngredientsSO.ingredientPrefab.transform.rotation);
    }
}
