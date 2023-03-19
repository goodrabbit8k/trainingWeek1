using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] StoveCounterManager stoveCounter;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;    
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounterManager.OnStateChangedEventArgs e)
    {
        bool playSoundEffect = e.state == StoveCounterManager.State.Frying || e.state == StoveCounterManager.State.Fried;

        if (playSoundEffect)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
