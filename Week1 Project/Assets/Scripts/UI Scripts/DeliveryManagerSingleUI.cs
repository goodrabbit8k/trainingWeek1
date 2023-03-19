using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipeNameText;
    [SerializeField] Transform iconsContainer;
    [SerializeField] Transform iconsTemplate;

    void Awake()
    {
        iconsTemplate.gameObject.SetActive(false);   
    }

    public void SetRecipeSO(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;

        foreach (Transform child in iconsContainer)
        {
            if (child == iconsTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (KitchenIngredientSO kitchenIngredientSO in recipeSO.kitchenIngredientSOList)
        {
            Transform iconsTransform = Instantiate(iconsTemplate, iconsContainer);
            iconsTransform.gameObject.SetActive(true);
            iconsTransform.GetComponent<Image>().sprite = kitchenIngredientSO.sprite;
        }
    }
}
