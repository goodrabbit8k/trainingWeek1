using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenIngredient : KitchenIngredient
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenIngredientSO kitchenIngredientSO;
    }

    List<KitchenIngredientSO> kitchenIngredientSOList;

    [SerializeField] List<KitchenIngredientSO> validKitchenIngredientSOList;

    void Awake()
    {
        kitchenIngredientSOList = new List<KitchenIngredientSO>();    
    }

    public bool TryAddIngredient(KitchenIngredientSO kitchenIngredientSO)
    {
        if (!validKitchenIngredientSOList.Contains(kitchenIngredientSO))
        {
            return false;
        }

        if (kitchenIngredientSOList.Contains(kitchenIngredientSO))
        {
            return false;
        }
        else
        {
            kitchenIngredientSOList.Add(kitchenIngredientSO);

            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { kitchenIngredientSO = kitchenIngredientSO });

            return true;
        }
    }

    public List<KitchenIngredientSO> GetKitchenIngredientSOList()
    {
        return kitchenIngredientSOList;
    }
}
