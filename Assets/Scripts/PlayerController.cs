using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rgd;

    [Header("Layers")]
    [SerializeField]
    private LayerMask ObstacleLayer;
    [SerializeField]
    private LayerMask ScoreLayer;

    [Header("Events")]
    [SerializeField]
    private UnityEvent OnJumped;
    [SerializeField]
    private UnityEvent OnDied;
    [SerializeField]
    private UnityEvent OnScored;

    [Header("Player Status")]
    public float JumpPower = 5.0f;


    private Animator animator;

    private void Awake()
    {
        rgd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Rotate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & ObstacleLayer) != 0)
        {
            OnDied?.Invoke();
            animator.SetBool("IsDied", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & ScoreLayer) != 0)
        {
            OnScored?.Invoke();
            GameManager.Data.CurScore++;
        }
    }


    private void OnJump() 
    {
        jump();
        OnJumped?.Invoke();
    }

    public void jump() 
    {
        //rgd.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        rgd.velocity = Vector2.up * JumpPower;
    }

    public void Rotate() 
    {
        //transform.right = (rgd.velocity + Vector2.right) * 1f;
        transform.right = rgd.velocity + Vector2.right * GameManager.Data.MoveSpeed;
    }

}
