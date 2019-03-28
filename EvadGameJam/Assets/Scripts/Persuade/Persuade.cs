using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persuade : MonoBehaviour
{
    public KeyCode actionButton;
    public GameObject dialogParticle;
    public PlayerMovement playerMovement;

    private void Update()
    {
        if(Input.GetKey(actionButton))
        {
            dialogParticle.SetActive(true);
            playerMovement.falling = true;
        }
        else
        {
            dialogParticle.SetActive(false);
            playerMovement.falling = false;
        }
    }
}
