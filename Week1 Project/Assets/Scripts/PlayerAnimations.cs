using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator playerAnimations;
    PlayerManager playerManager;

    void Awake()
    {
        playerAnimations = GetComponent<Animator>();
        playerManager = GameObject.Find("Player").GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        playerAnimations.SetBool("isMoving", playerManager.PlayerMovingCondition());
    }
}
