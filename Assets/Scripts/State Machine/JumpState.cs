using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IState
{
    public void OnEnter(StateController controller)
    {
        controller.audioSource.clip = controller.sfx[Random.Range(3, 6)];
        controller.audioSource.Play();
    }

    public void UpdateState(StateController controller)
    {
        if (!controller.character.jumping)
        {
            controller.characterAccelerateTimer = 6;
            controller.ChangeState(controller.accelerateState);
        }
    }

    public void OnExit(StateController controller)
    {
    }

    public void OnTurn(StateController controller)
    {
    }



}
