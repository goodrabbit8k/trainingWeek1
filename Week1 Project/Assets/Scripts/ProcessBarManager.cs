using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBarManager : MonoBehaviour
{
    [SerializeField] CuttingCounterManager cuttingCounter;
    [SerializeField] Image barImage;

    void Start()
    {
        cuttingCounter.onProcessChange += CuttingCounter_onProcessChange;    

        barImage.fillAmount = 0;

        gameObject.SetActive(false);
    }

    private void CuttingCounter_onProcessChange(object sender, CuttingCounterManager.onProcessChangeEventArgs e)
    {
        barImage.fillAmount = e.processNormalized;

        if (e.processNormalized == 0f || e.processNormalized == 1f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
