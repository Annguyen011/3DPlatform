using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run")]
public class PlayerState_Run : PlayerState
{
    [SerializeField] float runSpeed = 5f;

    [SerializeField] float aceration = 5f;

    public override void Enter()
    {
        base.Enter();

        currentSpeed = player.MoveSpeed;
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }

        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }

        if (!player.IsGrouned)
        {
            stateMachine.SwitchState(typeof (PlayerState_Corytime));
        }

        currentSpeed = Mathf.MoveTowards(currentSpeed, runSpeed, aceration * Time.deltaTime);
    }

    public override void PhysicsUpdate()
    {
        player.Move(currentSpeed);
    }
}
