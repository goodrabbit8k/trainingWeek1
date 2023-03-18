using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenIngredientSO input;
    public KitchenIngredientSO output;
    public float maximumFryingTime;
}
