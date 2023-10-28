using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningState : IState
{
    float timeElapsed;
    public void OnEnter(StateController controller)
    {
        controller.audioSource.Stop();
        controller.audioSource.clip = controller.sfx[2];
        controller.audioSource.Play();

        if(controller.characterAccelerateTimer >= 6)
        {
            controller.audioSource.time = 0;
        }
        else
        {
            //Debug.Log(controller.characterAccelerateTimer);
            controller.audioSource.time = controller.characterAccelerateTimer;
        }

        timeElapsed = 0f;
    }
    public void UpdateState(StateController controller)
    {
        controller.characterTurning = controller.character.rotations;
        if (!controller.characterTurning)
        {
            if(timeElapsed < 6)
            {
                controller.characterAccelerateTimer = controller.audioSource.time;
            }
            else
            {
                controller.characterAccelerateTimer = 6;
            }
            controller.ChangeState(controller.accelerateState);
        }
        if(controller.audioSource.time > 5.99f)
        {
            controller.characterAccelerateTimer = 6;
            controller.ChangeState(controller.accelerateState);
        }
        timeElapsed += Time.deltaTime;
    }

    public void OnExit(StateController controller)
    {
    }

    public void OnTurn(StateController controller)
    {
    }
}
