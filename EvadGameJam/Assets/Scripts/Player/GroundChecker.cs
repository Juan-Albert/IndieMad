using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public PlayerMovement parent;
    public ParticleSystem teamChangeParticles;
    public GameObject fallParticles, dustParticles;
    public Vector2 respawn;
    public SpriteRenderer[] bodyParts;
    private bool onRed = false, onBlue = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedZone"))
        {
            teamChangeParticles.Play();
            onRed = true;
            parent.body.sprite = parent.redSuit;
            parent.playerInfo.team = Team.Red;
        }
        else if (collision.gameObject.CompareTag("BlueZone"))
        {
            teamChangeParticles.Play();
            onBlue = true;
            parent.body.sprite = parent.blueSuit;
            parent.playerInfo.team = Team.Blue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            var smoke = Instantiate(fallParticles, this.transform.position, Quaternion.identity) as GameObject;
            smoke.GetComponent<ParticleSystemRenderer>().sortingOrder = parent.transform.position.y < -4 ? 999 : -2;
            smoke.GetComponent<ParticleSystem>().Play();
            Destroy(smoke, 4f);
            parent.falling = true;
            dustParticles.SetActive(false);
            foreach(var bodyPart in bodyParts)
            {
                bodyPart.color = new Color(255, 255, 255, 0);
            }
            StartCoroutine(Fall());
            
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

    IEnumerator Fall()
    {
        parent.body.sprite = parent.graySuit;
        parent.playerInfo.team = Team.None;
        parent.transform.position = respawn;

        for(int i = 0; i < 8; i++)
        {
            foreach (var bodyPart in bodyParts)
            {
                bodyPart.color = new Color(255, 255, 255, 0);
            }
            yield return new WaitForSeconds(0.25f);
            foreach (var bodyPart in bodyParts)
            {
                bodyPart.color = new Color(255, 255, 255, 255);
            }
            yield return new WaitForSeconds(0.15f);
        }

        dustParticles.SetActive(true);
        parent.falling = false;

    }
}
