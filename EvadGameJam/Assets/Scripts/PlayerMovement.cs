using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;
    public bool onlyHorizontalMove;
    public bool canDash;
    public float dashSpeed;
    public float startDashTime;
    public float startDashDuration;
    public float startStunDuration;

    public string hAxis;
    public string vAxis;

    [Header("Clothing Settings")]
    public Sprite stunFace;
    public Sprite normalFace;
    public SpriteRenderer face;
    public Sprite redSuit;
    public Sprite blueSuit;
    public Sprite graySuit;
    public SpriteRenderer body;

    [Header("Player Settings")]
    public PlayerInfo playerInfo;
    public KeyCode actionButton;
    public Animator myAnim;

    [HideInInspector]
    public bool falling = false;
    [HideInInspector]
    public bool stunned = false;


    private bool dashing = false;
    private bool tryDashing = false;
    private float dashTime;
    private float dashDuration;
    private float stunDuration;


    private Rigidbody2D myRB;
    private Vector2 moveVelocity;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        stunDuration = startStunDuration;
        dashTime = startDashTime;
        dashDuration = startDashDuration;
    }

    private void Update()
    {
        if(falling)
        {
            ResolveFall();
        }
        else if (stunned)
        {
            ResolveStun();
            face.sprite = stunFace;
        }
        else
        {
            face.sprite = normalFace;
            CheckInputs();
            if (moveVelocity.x > 0) transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            else if (moveVelocity.x < 0) transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);

            if (Input.GetKeyDown(actionButton) && moveVelocity != Vector2.zero) tryDashing = true;

            Dash();
        }
        myAnim.SetFloat("Speed", Mathf.Abs(moveVelocity.x) + Mathf.Abs(moveVelocity.y));

        myAnim.SetBool("Dashing", dashing);
        myAnim.SetBool("Stunned", stunned);
    }

    private void FixedUpdate()
    {
        if (dashing) myRB.MovePosition(myRB.position + moveVelocity * dashSpeed * Time.fixedDeltaTime);
        else myRB.MovePosition(myRB.position + moveVelocity * Time.fixedDeltaTime);
    }

    void CheckInputs()
    {
        Vector2 move;
        
        if (onlyHorizontalMove == true) move = new Vector2(Input.GetAxis(hAxis), 0);
        else move = new Vector2(Input.GetAxis(hAxis), -Input.GetAxis(vAxis));

        moveVelocity = move.normalized * speed;
        
    }

    void Dash()
    {
        if(canDash)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0 && tryDashing && !stunned)
            {
                if (dashDuration <= 0)
                {
                    dashTime = startDashTime;
                    dashDuration = startDashDuration;
                    dashing = false;
                    tryDashing = false;
                }
                else
                {
                    dashDuration -= Time.deltaTime;
                    dashing = true;
                }
            }
            else
            {
                tryDashing = false;
                dashing = false;
            }
        }
    }

    void ResolveFall()
    {
        moveVelocity = Vector2.zero;

    }

    void ResolveStun()
    {
        moveVelocity = Vector2.zero;
        stunDuration -= Time.deltaTime;
        if (stunDuration <= 0)
        {
            stunned = false;
            stunDuration = startStunDuration;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.CompareTag("Player") && dashing)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>() != null) collision.gameObject.GetComponent<PlayerMovement>().stunned = true;
            if(collision.gameObject.GetComponent<Rigidbody2D>() != null) collision.gameObject.GetComponent<Rigidbody2D>().AddForce(moveVelocity * 50);
        }
    }

    

   

}
