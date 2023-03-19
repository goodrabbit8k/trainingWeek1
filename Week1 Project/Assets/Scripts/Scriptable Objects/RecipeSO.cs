using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public List<KitchenIngredientSO> kitchenIngredientSOList;
    public string recipeName;
}
