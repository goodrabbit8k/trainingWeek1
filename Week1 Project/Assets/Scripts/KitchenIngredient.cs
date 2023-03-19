using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenIngredient : MonoBehaviour
{
    [SerializeField] KitchenIngredientSO kitchenIngredientSO;

    IKitchenIngredientParent kitchenIngredientParent;

    public KitchenIngredientSO GetKitchenIngredientSO()
    {
        return kitchenIngredientSO;
    }

    public void SetKitchenIngredientParent(IKitchenIngredientParent kitchenIngredientParent)
    {
        if (this.kitchenIngredientParent != null)
        {
            this.kitchenIngredientParent.ClearKitchenIngredient();
        }

        this.kitchenIngredientParent = kitchenIngredientParent;
        kitchenIngredientParent.SetKitchenIngredient(this);

        transform.parent = kitchenIngredientParent.GetKitchenIngredientFollowSpawnPoint();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenIngredientParent GetKitchenIngredientParent()
    {
        return kitchenIngredientParent;
    }

    public void DestroyIngredient()
    {
        kitchenIngredientParent.ClearKitchenIngredient();

        Destroy(gameObject);
    }

    public bool TryGetPlate(out PlateKitchenIngredient plateKitchenIngredient)
    {
        if (this is PlateKitchenIngredient)
        {
            plateKitchenIngredient = this as PlateKitchenIngredient;
            return true;
        }
        else
        {
            plateKitchenIngredient = null;
            return false;
        }
    }

    public static KitchenIngredient SpawnKitchenIngredient(KitchenIngredientSO kitchenIngredientSO, IKitchenIngredientParent kitchenIngredientParent)
    {
        Transform kitchenIngredientSpawnPos = Instantiate(kitchenIngredientSO.prefab);
        KitchenIngredient kitchenIngredient = kitchenIngredientSpawnPos.GetComponent<KitchenIngredient>();
        
        kitchenIngredient.SetKitchenIngredientParent(kitchenIngredientParent);

        return kitchenIngredient;
    }
}
