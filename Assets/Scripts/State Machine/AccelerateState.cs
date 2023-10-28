using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateState : IState
{
    float timeBeforeFullAccelerate;
    public void OnEnter(StateController controller)
    {
        timeBeforeFullAccelerate = controller.characterAccelerateTimer;
        controller.audioSource.clip = controller.sfx[0];
        controller.audioSource.Play();
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

        controller.characterTurning = controller.character.rotations;
        if (controller.characterTurning)
        {
            controller.characterAccelerateTimer = timeBeforeFullAccelerate;
            controller.ChangeState(controller.turningState);
        }

        if(timeBeforeFullAccelerate < 0) 
        {
            controller.ChangeState(controller.fullEngineState);
        }

        timeBeforeFullAccelerate -= Time.deltaTime;
    }
    public void OnExit(StateController controller)
    {
    }

    public void OnCrash(StateController controller)
    {
        controller.ChangeState(controller.deadState);
    }
}
