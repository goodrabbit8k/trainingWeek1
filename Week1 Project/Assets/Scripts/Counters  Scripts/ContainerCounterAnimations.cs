using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnimations : MonoBehaviour
{
    [SerializeField] ContainerCounterManager containerCounter;

    Animator containerCounterAnimations;

    void Awake()
    {
        containerCounterAnimations = GetComponent<Animator>();   
    }

    void Start()
    {
        containerCounter.onPlayerHoldingIngredient += ContainerCounter_onPlayerHoldingIngredient;   
    }

    private void ContainerCounter_onPlayerHoldingIngredient(object sender, System.EventArgs e)
    {
        containerCounterAnimations.SetTrigger("OpenClose");
    }
}
