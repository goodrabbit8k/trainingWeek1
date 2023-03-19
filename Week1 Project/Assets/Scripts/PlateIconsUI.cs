using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] PlateKitchenIngredient plateKitchenIngredient;
    [SerializeField] Transform iconTemplete;


    private void Awake()
    {
        iconTemplete.gameObject.SetActive(false);    
    }
    
    void Start()
    {
        plateKitchenIngredient.OnIngredientAdded += PlateKitchenIngredient_OnIngredientAdded;    
    }

    private void PlateKitchenIngredient_OnIngredientAdded(object sender, PlateKitchenIngredient.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplete) continue;
            Destroy(child.gameObject);
        }

        foreach(KitchenIngredientSO kitchenIngredientSO in plateKitchenIngredient.GetKitchenIngredientSOList())
        {
            Transform iconTransform = Instantiate(iconTemplete, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconsSingleUI>().SetKitchenIngredientSO(kitchenIngredientSO);
        }
    }
}
