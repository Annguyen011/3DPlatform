using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerInput input;

    Rigidbody rb;

    PlayerGroundDetector groundDetector;

    public bool CanAirJump { get; set; }
    public bool IsGrouned => groundDetector.IsGrounded;

    public bool IsFall => !IsGrouned && rb.velocity.y < 0;

    public float MoveSpeed => Mathf.Abs(rb.velocity.x);

    public AudioSource voicePlayer { set; get; }

    public bool victory;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        voicePlayer = GetComponentInChildren<AudioSource>();
    }
    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    void OnlevelClear()
    {
        victory = true;
    }

    private void Start()
    {
        input.EnableGamePlayInput();
    }
    private void Update()
    {
    }

    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxisX, 1, 1);
        }

        SetVelocityX(speed * input.AxisX);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    public void SetGravity(bool value)
    {
        rb.useGravity = value;
    }
}
