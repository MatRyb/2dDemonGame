using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampState : IState
{
    public void OnCrash(StateController controller)
    {
        controller.ChangeState(controller.deadState);
    }

    public void OnEnter(StateController controller)
    {
        controller.audioSource.Stop();
        controller.audioSource.clip = controller.sfx[7];
        controller.audioSource.Play();
    }

    public void OnExit(StateController controller)
    {
    }

    public void UpdateState(StateController controller)
    {
        if (!controller.character.movable)
        {
            OnCrash(controller);
        }

        if (!controller.character.slowed)
        {
            controller.characterAccelerateTimer = 6;
            controller.ChangeState(controller.accelerateState);
        }

        if (controller.character.jumping)
        {
            controller.ChangeState(controller.jumpState);
        }
    }
}
