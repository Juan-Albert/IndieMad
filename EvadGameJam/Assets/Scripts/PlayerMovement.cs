using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool onlyHorizontalMove;

    public string hAxis;
    public string vAxis;

    private Rigidbody2D myRB;
    private Vector2 moveVelocity;

    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        CheckInputs();
    }

    private void FixedUpdate()
    {
        myRB.MovePosition(myRB.position + moveVelocity * Time.fixedDeltaTime);
    }

    void CheckInputs()
    {
        Vector2 move;
        
        if (onlyHorizontalMove == true) move = new Vector2(Input.GetAxis(hAxis), 0);
        else move = new Vector2(Input.GetAxis(hAxis), -Input.GetAxis(vAxis));

        moveVelocity = move.normalized * speed;
        
    }
}
