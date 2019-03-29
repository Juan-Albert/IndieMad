using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuade : MonoBehaviour
{
    public KeyCode actionButton;
    public GameObject dialogParticle;
    public PlayerMovement playerMovement;
    public PlayerInfo playerInfo;

    private NPCZombieController voter;
    private bool persuading = false;

    private void Update()
    {
        if(Input.GetKey(actionButton))
        {
            dialogParticle.SetActive(true);
            playerMovement.falling = true;

            if(persuading) voter.BeingPersuaded(playerInfo.team);
        }
        else
        {
            dialogParticle.SetActive(false);
            playerMovement.falling = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("NPC"))
        {
            persuading = true;
            voter = collision.gameObject.GetComponent<NPCZombieController>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            persuading = false;
        }
    }
}
