using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed;
    public bool onlyHorizontalMove;

    public string hAxis;
    public string vAxis;

    [Header("Player Settings")]
    public PlayerInfo playerInfo;
    public KeyCode actionButton;
    public Animator myAnim;

    public GameObject redStamp, blueStamp;
    public StampManager stampManager;

    private Rigidbody2D myRB;
    private Vector2 moveVelocity;

    private void Awake()
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
        

        if (Input.GetKeyDown(actionButton))
        {
            myAnim.SetTrigger("Stamp");
            Debug.DrawLine(transform.position, transform.position + new Vector3(0.5f, 0f, 0f),Color.white, 50f);
            RaycastHit2D[] hitColliders = Physics2D.CircleCastAll(transform.position, 0.5f, new Vector2(0,0));
            int maxLayer = -1;
            GameObject envelope = null;
            foreach(var collision in hitColliders)
            {
                if(collision.transform.gameObject.CompareTag("Envelope"))
                {
                    int currentLayer = collision.transform.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
                    if (currentLayer > maxLayer)
                    {
                        maxLayer = currentLayer;
                        envelope = collision.transform.gameObject;
                    }
                }
                
            }

            if (envelope != null)
            {
                if(!envelope.GetComponent<Envelope>().stamped)
                {
                    Debug.Log("Te estampo");
                    envelope.GetComponent<Envelope>().stamped = true;
                    GameObject stamp;
                    if (playerInfo.team == Team.Blue)
                    {
                        stampManager.BlueStamp();
                        stamp = Instantiate(blueStamp, transform.position, transform.rotation, envelope.transform) as GameObject;
                    }
                    else
                    {
                        stampManager.RedStamp();
                        stamp = Instantiate(redStamp, transform.position, transform.rotation, envelope.transform) as GameObject;
                    }

                    stamp.GetComponent<SpriteRenderer>().sortingOrder = maxLayer + 1;
                }
            }
        }

    }
}
