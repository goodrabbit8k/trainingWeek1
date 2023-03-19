using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenIngredientSO_GameObject
    {
        public KitchenIngredientSO kitchenIngredientSO;
        public GameObject gameObject;
    }

    [SerializeField] List<KitchenIngredientSO_GameObject> kitchenIngredientSOGameObjectList;
    [SerializeField] PlateKitchenIngredient plateKitchenIngredient;

    void Start()
    {
        plateKitchenIngredient.OnIngredientAdded += PlateKitchenIngredient_OnIngredientAdded;

        foreach (KitchenIngredientSO_GameObject kitchenIngredientSOGameObject in kitchenIngredientSOGameObjectList)
        {
            kitchenIngredientSOGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenIngredient_OnIngredientAdded(object sender, PlateKitchenIngredient.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenIngredientSO_GameObject kitchenIngredientSOGameObject in kitchenIngredientSOGameObjectList)
        {
            if (kitchenIngredientSOGameObject.kitchenIngredientSO == e.kitchenIngredientSO)
            {
                kitchenIngredientSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
