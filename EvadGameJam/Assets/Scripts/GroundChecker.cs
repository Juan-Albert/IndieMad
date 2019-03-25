using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public PlayerMovement parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedZone"))
        {
            parent.body.sprite = parent.redSuit;
            parent.playerInfo.team = Team.Red;
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            parent.body.sprite = parent.blueSuit;
            parent.playerInfo.team = Team.Blue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("ME caigo");
        }

        if (collision.gameObject.CompareTag("RedZone"))
        {
            if (parent.playerInfo.team == Team.Red)
            {
                parent.body.sprite = parent.graySuit;
                parent.playerInfo.team = Team.None;
            }
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            if (parent.playerInfo.team == Team.Blue)
            {
                parent.body.sprite = parent.graySuit;
                parent.playerInfo.team = Team.None;
            }
        }
    }
}
