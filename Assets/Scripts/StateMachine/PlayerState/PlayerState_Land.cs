using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float stiffTime = .1f;
    public override void Enter()
    {
        base.Enter();

        player.CanAirJump = true;
        player.SetVelocity(Vector3.zero);
    }

    public override void LogicUpdate()
    {
        if (  input.hasJumpInputBuffer||input.Jump)
        {
            stateMachine.SwitchState(typeof(PlayerState_Jump));
        }

        if (StateDuration < stiffTime)
        {
            return;
        }

        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

        if (IsAnimationFinished)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
    }
}
