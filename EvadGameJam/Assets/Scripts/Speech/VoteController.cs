using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoteController : MonoBehaviour
{
    public string voteAxis;
    public SpeechManager speechManager;
    public PlayerInfo playerInfo;
    public float startIdleTimer;

    private Animator myAnim;
    private float idleTimer;
    private bool upInUse = false;
    private bool downInUse = false;

    private void Awake()
    {
        myAnim = gameObject.GetComponent<Animator>(); 
    }

    private void Start()
    {
        idleTimer = startIdleTimer;
    }

    private void Update()
    {
        
        if (Input.GetAxisRaw(voteAxis) > 0)
        {
            upInUse = true;
            if (downInUse == false)
            {
                myAnim.SetBool("Hate", true);
                myAnim.SetBool("Cheer", false);

                downInUse = true;
                speechManager.Hate();
                idleTimer = startIdleTimer;
            }
            else
            {
                idleTimer -= Time.deltaTime;
                if (idleTimer < 0)
                {
                    myAnim.SetBool("Hate", false);
                    idleTimer = startIdleTimer;
                }
            }
        }
        else if (Input.GetAxisRaw(voteAxis) < 0)
        {
            downInUse = false;
            if (upInUse == false)
            {
                myAnim.SetBool("Cheer", true);
                myAnim.SetBool("Hate", false);
                upInUse = true;
                speechManager.Cheer();
                idleTimer = startIdleTimer;
            }
            else
            {
                idleTimer -= Time.deltaTime;
                if (idleTimer < 0)
                {
                    myAnim.SetBool("Cheer", false);
                    idleTimer = startIdleTimer;
                }
            }
        }
        else
        {
            upInUse = false;
            downInUse = false;
            idleTimer -= Time.deltaTime;
            if(idleTimer < 0)
            {
                myAnim.SetBool("Cheer", false);
                myAnim.SetBool("Hate", false);
                idleTimer = startIdleTimer;
            }
        }

    }
}
