using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullEngineState : IState
{
    public void OnEnter(StateController controller)
    {
        controller.audioSource.clip = controller.sfx[1];
        controller.audioSource.Play();
        controller.audioSource.loop = true;
    }
    public void UpdateState(StateController controller)
    {
        if (!controller.character.movable)
        {
            OnCrash(controller);
        }

        if (controller.character.jumping)
        {
            controller.ChangeState(controller.jumpState);
        }

        if (controller.character.slowed)
        {
            controller.ChangeState(controller.swampState);
        }

        controller.characterTurning = controller.character.rotations;
        if (controller.characterTurning)
        {
            controller.characterAccelerateTimer = 6;
            controller.audioSource.loop = false;
            controller.ChangeState(controller.turningState);
        }
    }
    public void OnExit(StateController controller)
    {
    }

    public void OnCrash(StateController controller)
    {
        controller.ChangeState(controller.deadState);
    }
}
