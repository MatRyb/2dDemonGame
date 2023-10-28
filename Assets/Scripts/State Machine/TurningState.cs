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
        else if(controller.characterAccelerateTimer < 0)
        {
            controller.audioSource.time = 0;
        }
        else
        {   
            controller.audioSource.time = controller.characterAccelerateTimer;
        }

        timeElapsed = 0f;


        if(Random.Range(0,2) < 1)
        {
            controller.character.gameObject.GetComponent<AudioSource>().clip = controller.character.gameObject.GetComponent<CharacterMove>().clips[Random.Range(0, 3)];
            controller.character.gameObject.GetComponent<AudioSource>().Play();
        }
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
            controller.character.gameObject.GetComponent<AudioSource>().Stop();
        }
        if(controller.audioSource.time > 5.99f)
        {
            controller.characterAccelerateTimer = 6;
            controller.ChangeState(controller.accelerateState);
            controller.character.gameObject.GetComponent<AudioSource>().Stop();
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
