using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KitchenIngredientSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string ingredientName;
}
