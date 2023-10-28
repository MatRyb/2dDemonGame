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
        controller.characterTurning = controller.character.rotations;
        if (controller.characterTurning)
        {
            controller.characterAccelerateTimer = 6;
            controller.ChangeState(controller.turningState);
        }
    }

    public void OnTurn(StateController controller)
    {
        controller.audioSource.loop = false;
        controller.ChangeState(controller.turningState);
    }

    public void OnExit(StateController controller)
    {
    }
}
