using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterAnimations : MonoBehaviour
{
    [SerializeField] StoveCounterManager stoveCounter;
    [SerializeField] GameObject stoveOnVisual;
    [SerializeField] GameObject stoveOnParticlesVisual;

    void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;    
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounterManager.OnStateChangedEventArgs e)
    {
        bool showAnimations = e.state == StoveCounterManager.State.Frying || e.state == StoveCounterManager.State.Fried;

        stoveOnVisual.SetActive(showAnimations);
        stoveOnParticlesVisual.SetActive(showAnimations);
    }
}
