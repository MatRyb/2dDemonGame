using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    public void OnCrash(StateController controller)
    {

    }

    public void OnEnter(StateController controller)
    {
        controller.audioSource.Stop();
        controller.audioSource.clip = controller.sfx[6];
        controller.audioSource.Play();

        // Freeze all movement
        // Stop all jumping
        
    }

    public void OnExit(StateController controller)
    {

    }

    public void UpdateState(StateController controller)
    {

    }
}
