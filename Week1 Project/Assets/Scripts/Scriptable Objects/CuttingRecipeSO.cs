using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    public KitchenIngredientSO input;
    public KitchenIngredientSO output;
    public int maximumCuttingProcess;
}
