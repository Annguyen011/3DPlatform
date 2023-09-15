using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump")]
public class PlayerState_Jump : PlayerState
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] ParticleSystem jumpVFX; 
    [SerializeField] AudioClip jumpSFX;
    public override void Enter()
    {
        base.Enter();

        input.hasJumpInputBuffer = false;
        player.voicePlayer.PlayOneShot(jumpSFX);
        player.SetVelocityY(jumpForce);
        Instantiate(jumpVFX, player.transform.position, Quaternion.identity);
    }

    public override void LogicUpdate()
    {
        if (input.StopJump || player.IsFall)
        {
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicsUpdate()
    {
        player.Move(moveSpeed);
    }
}
