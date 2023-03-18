using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterAnimations : MonoBehaviour
{
    [SerializeField] CuttingCounterManager cuttingCounter;

    Animator containerCounterAnimations;

    void Awake()
    {
        containerCounterAnimations = GetComponent<Animator>();   
    }

    void Start()
    {
        cuttingCounter.onCutting += CuttingCounter_onCutting;
    }

    private void CuttingCounter_onCutting(object sender, System.EventArgs e)
    {
        containerCounterAnimations.SetTrigger("Cut");
    }
}
