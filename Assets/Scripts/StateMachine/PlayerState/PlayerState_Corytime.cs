using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Coytetime")]

public class PlayerState_Corytime : PlayerState
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField ]float coytime = .1f;

    public override void Enter()
    {
        base.Enter();
        player.SetGravity(false);
        currentSpeed = player.MoveSpeed;
    }

    public override void Exit()
    {
        player.SetGravity(true);
    }

    public override void LogicUpdate()
    {
       
        if (input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }

        if (StateDuration > coytime|| !input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }

    }

    public override void PhysicsUpdate()
    {
        player.Move(runSpeed);
    }
}
