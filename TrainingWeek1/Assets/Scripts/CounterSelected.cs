using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSelected : MonoBehaviour
{
    [SerializeField] private ClearCounterManager clearCounter;
    [SerializeField] private GameObject clearCounterVisual;

    void Start()
    {
        PlayerManager.instance.ChangeSelectedCounterEvent += Instance_ChangeSelectedCounterEvent;
    }

    private void Instance_ChangeSelectedCounterEvent(object sender, PlayerManager.ChangeSelectedCounterEventArgs e)
    {
        if (e.clearCounterSelect == clearCounter)
        {
            OnVisual();
        }
        else
        {
            offVisual();
        }
    }

    void OnVisual()
    {
        clearCounterVisual.SetActive(true);
    }

    void offVisual()
    {
        clearCounterVisual.SetActive(false);
    }
}
