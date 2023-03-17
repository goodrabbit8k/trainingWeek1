using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] ClearCounterManager clearCounter;
    [SerializeField] GameObject selectedVisual;

    void Start()
    {
        PlayerManager.Instance.OnSelectedCounter += Player_OnSelectedCounter;
    }

    private void Player_OnSelectedCounter(object sender, PlayerManager.OnSelectedCounterEventArgs e)
    {
        if (e.selectedCounter == clearCounter)
        {
            selectedVisual.gameObject.SetActive(true);
        }
        else
        {
            selectedVisual.gameObject.SetActive(false);
        }
    }
}
