using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    public void OnEnter(StateController controller)
    {
        controller.audioSource.Stop();
        controller.audioSource.clip = controller.sfx[Random.Range(3, 6)];
        controller.audioSource.volume = 1.0f;
        controller.audioSource.Play();
    }

    public void UpdateState(StateController controller)
    {
        if (!controller.character.jumping)
        {
            controller.characterAccelerateTimer = 6;
            controller.audioSource.volume = 0.5f;
            controller.ChangeState(controller.accelerateState);
        }
    }

    public void OnExit(StateController controller)
    {
    }

    public void OnCrash(StateController controller)
    {
        // right... you are immune during jump TOO BROKEN GUYS ~/Mateusz 29.10.2023
    }
}
