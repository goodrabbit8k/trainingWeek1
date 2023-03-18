using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBarManager : MonoBehaviour
{
    [SerializeField] GameObject hasProcessGameObject;
    [SerializeField] Image barImage;

    IHasProcess hasProcess;

    void Start()
    {
        hasProcess = hasProcessGameObject.GetComponent<IHasProcess>();

        if (hasProcess == null)
        {
            Debug.LogError("Game Object " + hasProcessGameObject + " does not have a component that implemets IHasProgress");
        }

        hasProcess.onProcessChange += HasProcess_onProcessChange;    

        barImage.fillAmount = 0;

        gameObject.SetActive(false);
    }

    private void HasProcess_onProcessChange(object sender, IHasProcess.onProcessChangeEventArgs e)
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
