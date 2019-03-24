using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool onlyHorizontalMove;
    public bool canDash;
    public float dashSpeed;
    public float startDashTime;
    public float startDashDuration;

    public PlayerInfo playerInfo;

    public string hAxis;
    public string vAxis;

    private bool dashing = false;
    private bool tryDashing = false;
    private float dashTime;
    private float dashDuration;


    private Rigidbody2D myRB;
    private Vector2 moveVelocity;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        dashDuration = startDashDuration;
    }

    private void Update()
    {
        CheckInputs();

        if ((Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick2Button1)
                    || Input.GetKeyDown(KeyCode.Joystick3Button1) || Input.GetKeyDown(KeyCode.Joystick4Button1)) && moveVelocity != Vector2.zero)
        {
            tryDashing = true;
        }
        Dash();

    }

    private void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + moveVelocity * Time.fixedDeltaTime);

        if (dashing) myRB.MovePosition(myRB.position + moveVelocity * dashSpeed * Time.fixedDeltaTime);
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
            if (dashTime <= 0 && tryDashing)
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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedZone"))
        {
            GameManager.instance.playersTeam[playerInfo.id] = Team.Red;
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            GameManager.instance.playersTeam[playerInfo.id] = Team.Blue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedZone"))
        {
            if (GameManager.instance.playersTeam[playerInfo.id] == Team.Red) GameManager.instance.playersTeam[playerInfo.id] = Team.None;
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            if (GameManager.instance.playersTeam[playerInfo.id] == Team.Blue) GameManager.instance.playersTeam[playerInfo.id] = Team.None;
        }
    }

   

}
