using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] protected string stateName;
    [SerializeField] protected float transitionDuration = .1f;

    float stateStartTime;

    int stateHash;
    protected float currentSpeed;

    protected Animator animator;

    protected PlayerController player;

    protected PlayerStateMachine stateMachine;

    protected PlayerInput input;

    protected bool IsAnimationFinished => StateDuration>= animator.GetCurrentAnimatorClipInfo(0).Length;

    public float StateDuration => Time.time - stateStartTime;

    public void Initialize(Animator animator, PlayerController player, PlayerInput input, PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.input = input;
        this.player = player;
    }

    private void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);
    }

    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);

        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
    }
}
