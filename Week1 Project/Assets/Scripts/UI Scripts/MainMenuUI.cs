using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button quitButton;

    void Awake()
    {
        playButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.SampleScene); });

        quitButton.onClick.AddListener(() => { Application.Quit(); });

        Time.timeScale = 1;
    }
}
