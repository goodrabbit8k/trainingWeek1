using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    PlayerManager player;

    float footstepTimer;
    float footstepTimerMax;

    void Awake()
    {
        player = GetComponent<PlayerManager>();    
    }

    void Update()
    {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;

            if (player.PlayerMovingCondition())
            {
                float volume = 0f;
                SoundManager.instance.PlayFootstepSound(player.transform.position, volume);
            }
        }
    }
}
