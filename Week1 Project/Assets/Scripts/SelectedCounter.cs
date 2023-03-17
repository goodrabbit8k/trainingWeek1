using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] selectedVisualArray;

    void Start()
    {
        PlayerManager.Instance.OnSelectedCounter += Player_OnSelectedCounter;
    }

    private void Player_OnSelectedCounter(object sender, PlayerManager.OnSelectedCounterEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            foreach (GameObject selectedVisual in selectedVisualArray)
            {
                selectedVisual.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject selectedVisual in selectedVisualArray)
            {
                selectedVisual.SetActive(false);
            }
        }
    }
}
