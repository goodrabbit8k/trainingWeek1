using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        GameManager.instance.OnStateChanged += GameManager_OnStateChanged;

        gameObject.SetActive(false);
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.instance.IsCountdownToStartActive())
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        countdownText.text = Mathf.Ceil(GameManager.instance.GetCountdownToStartTimer()).ToString();    
    }
}
