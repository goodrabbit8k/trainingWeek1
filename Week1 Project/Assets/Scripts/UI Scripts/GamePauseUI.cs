using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;

    void Awake()
    {
        resumeButton.onClick.AddListener(() => { GameManager.instance.PauseGame(); });
        mainMenuButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.MainMenu); });
    }

    void Start()
    {
        GameManager.instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        Hide();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
