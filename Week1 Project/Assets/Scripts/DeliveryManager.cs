using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager instance { get; private set; }

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;

    [SerializeField] RecipeListSO recipeListSO;

    List<RecipeSO> customerRecipeSOList;

    float spawnRecipeTimer;
    float spawnRecipeTimerMax = 4f;
    int waitingRecipeMax = 4;
    int successfullRecipeAmount;

    void Awake()
    {
        instance = this;
        customerRecipeSOList = new List<RecipeSO>();   
    }

    void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if (customerRecipeSOList.Count < waitingRecipeMax)
            {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];

                customerRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void DeliveryRecipe(PlateKitchenIngredient plateKitchenIngredient)
    {
        for (int i = 0; i < customerRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = customerRecipeSOList[i];

            if (waitingRecipeSO.kitchenIngredientSOList.Count == plateKitchenIngredient.GetKitchenIngredientSOList().Count)
            {
                bool plateContentsMatchesRecipe = true;
                foreach (KitchenIngredientSO recipeKitchenIngredientSO in waitingRecipeSO.kitchenIngredientSOList)
                {
                    bool ingredientFound = false;
                    foreach (KitchenIngredientSO plateKitchenIngredientSO in plateKitchenIngredient.GetKitchenIngredientSOList())
                    {
                        if (plateKitchenIngredientSO == recipeKitchenIngredientSO)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }
                    if (!ingredientFound)
                    {
                        plateContentsMatchesRecipe = false;
                    }
                }

                if (plateContentsMatchesRecipe)
                {
                    successfullRecipeAmount++;
                    customerRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);

                    return;
                }
            }
        }

        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return customerRecipeSOList;
    }

    public int GetSuccessfullRecipeAmount()
    {
        return successfullRecipeAmount;
    }
}
