using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateController : MonoBehaviour
{
    IState currentState;
    public AccelerateState accelerateState = new AccelerateState();
    public FullEngineState fullEngineState = new FullEngineState();
    public TurningState turningState = new TurningState();
    public JumpState jumpState = new JumpState();
    public DeadState deadState = new DeadState();

    [SerializeField] public AudioSource audioSource;
    [SerializeField] public CharacterMove character;
    [SerializeField] public AudioClip[] sfx = null;

    [HideInInspector] public bool characterTurning;
    [HideInInspector] public float characterAccelerateTimer;

    private void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        characterAccelerateTimer = 6;
        characterTurning = false;
        ChangeState(accelerateState);
    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void ChangeState(IState newState)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}

public interface IState
{
    void OnExit(StateController controller);
    void OnEnter(StateController controller);
    void UpdateState(StateController controller);
    void OnCrash(StateController controller);
}
