using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterManager : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] KitchenIngredientSO plateKitchenIngredientSO;

    float spawnPlateTimer;
    float spawnPlateTimerMax = 4f;

    int plateSpawnedAmount;
    int plateSpawnedAmountMax = 4;

    void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;

            if (plateSpawnedAmount < plateSpawnedAmountMax)
            {
                plateSpawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interaction(PlayerManager player)
    {
        if (!player.HasKitchenIngredient())
        {
            if (plateSpawnedAmount > 0)
            {
                plateSpawnedAmount--;

                KitchenIngredient.SpawnKitchenIngredient(plateKitchenIngredientSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
