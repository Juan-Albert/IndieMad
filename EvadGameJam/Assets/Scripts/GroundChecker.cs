using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public PlayerMovement parent;

    private bool onRed = false, onBlue = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedZone"))
        {
            onRed = true;
            parent.body.sprite = parent.redSuit;
            parent.playerInfo.team = Team.Red;
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            onBlue = true;
            parent.body.sprite = parent.blueSuit;
            parent.playerInfo.team = Team.Blue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            parent.falling = true;
        }

        if (collision.gameObject.CompareTag("RedZone"))
        {
            if(onBlue)
            {
                onRed = false;
                parent.body.sprite = parent.blueSuit;
                parent.playerInfo.team = Team.Blue;
            }
            else if (parent.playerInfo.team == Team.Red)
            {
                onRed = false;
                parent.body.sprite = parent.graySuit;
                parent.playerInfo.team = Team.None;
            }
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            if(onRed)
            {
                onBlue = false;
                parent.body.sprite = parent.redSuit;
                parent.playerInfo.team = Team.Red;
            }
            else if (parent.playerInfo.team == Team.Blue)
            {
                onBlue = false;
                parent.body.sprite = parent.graySuit;
                parent.playerInfo.team = Team.None;
            }
        }
    }
}
