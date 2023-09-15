using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerActions playerInputActions;
    [SerializeField] float jumpInputBufferTime = .5f;

    WaitForSeconds waitJumpInputBuffertime;
    Vector2 axes => playerInputActions.Gameplay.Axis.ReadValue<Vector2>();
    public bool Jump => Input.GetButtonDown("Jump");
    public bool StopJump => Input.GetButtonUp("Jump");
    public bool Move => AxisX != 0;

    public bool hasJumpInputBuffer { set; get; }

    public float AxisX => axes.x;
    public float AxisY => axes.y;


    private void OnEnable()
    {

    }

    private void Awake()
    {
        playerInputActions = new PlayerActions();

        waitJumpInputBuffertime = new WaitForSeconds(jumpInputBufferTime);
    }

    public void EnableGamePlayInput()
    {
        playerInputActions.Gameplay.Axis.Enable();
    }

    public void SetJumpInputBufferTime()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        hasJumpInputBuffer = true;

        yield return waitJumpInputBuffertime;

        hasJumpInputBuffer = false;
    }
}
