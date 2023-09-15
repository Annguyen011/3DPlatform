using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AirJump")]

public class PlayerState_AirJump : PlayerState
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] ParticleSystem jumpVFX;
    [SerializeField] AudioClip jumpSFX; 

    public override void Enter()
    {
        base.Enter();
player.voicePlayer.PlayOneShot(jumpSFX);
        player.CanAirJump = false;

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
