using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()] 
public class KitchenScriptableObject : ScriptableObject
{
    public GameObject ingredientPrefab;
    public Sprite ingredientSprite;
    public string ingredientName;
}
