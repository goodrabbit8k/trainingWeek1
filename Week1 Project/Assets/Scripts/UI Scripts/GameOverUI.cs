using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipeDeliveredText;

    void Start()
    {
        GameManager.instance.OnStateChanged += GameManager_OnStateChanged;

        gameObject.SetActive(false);
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.instance.IsGameOver())
        {
            gameObject.SetActive(true);

            recipeDeliveredText.text = DeliveryManager.instance.GetSuccessfullRecipeAmount().ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
