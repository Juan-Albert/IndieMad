using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsController : MonoBehaviour
{
    public float scissorsSpeed;
    public float ribbonPos, outPos;
    public float barSpeed;
    public float barLimit, barsuccess;
    public Transform strengthMark;

    public GameObject openScissors, closeScissors;
    public GameObject cutObject;

    public PlayerInfo playerInfo;
    public KeyCode actionKey;

    private float initialPos;
    private bool barGoRight = true;
    private bool cutting = false;
    private bool success = false;
    private bool reach = false;
    private bool waiting = false;

    private void Awake()
    {
        initialPos = transform.position.y;
    }

    private void Update()
    {
        if (!cutting)
        {
            if (Input.GetKeyDown(actionKey))
            {
                cutting = true;
                CheckBar();
            }
            MoveBar();
        }
        else
        {
            TryCut();
        }

    }

    private void MoveBar()
    {
        if (barGoRight)
        {
            strengthMark.Translate(Vector3.right * barSpeed * Time.deltaTime);

            if (strengthMark.localPosition.x > barLimit)
            {
                barGoRight = false;
            }
        }
        else
        {
            strengthMark.Translate(Vector3.left * barSpeed * Time.deltaTime);

            if (strengthMark.localPosition.x < (-barLimit))
            {
                barGoRight = true;
            }
        }
    }

    private void CheckBar()
    {
        if (strengthMark.localPosition.x < barsuccess && strengthMark.localPosition.x > -barsuccess) success = true;
        else success = false;
    }

    private void TryCut()
    {
        if(!waiting)
        {
            if (!reach)
            {
                if (success)
                {
                    transform.Translate(Vector3.up * scissorsSpeed * Time.deltaTime);
                    if (transform.position.y > ribbonPos)
                    {
                        StartCoroutine(Cut());
                        cutObject.SetActive(false);
                    }
                }
                else
                {
                    transform.Translate(Vector3.up * scissorsSpeed * Time.deltaTime);
                    if (transform.position.y > outPos)
                    {
                        StartCoroutine(Cut());
                    }
                }
            }
            else
            {
                transform.Translate(Vector3.down * scissorsSpeed * Time.deltaTime);
                if (transform.position.y < initialPos)
                {
                    cutting = false;
                    reach = false;
                }
            }
        }
        
        
    }

    IEnumerator Cut()
    {
        waiting = true;
        openScissors.SetActive(false);
        closeScissors.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        closeScissors.SetActive(false);
        openScissors.SetActive(true);
        reach = true;
        waiting = false;

    }

}
