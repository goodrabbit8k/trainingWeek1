using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] Image timerImage;

    void Update()
    {
        timerImage.fillAmount = GameManager.instance.GetGamePlayingTimerNormalized();
    }
}
