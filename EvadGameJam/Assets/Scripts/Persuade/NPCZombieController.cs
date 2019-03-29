using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCZombieController : MonoBehaviour
{

    public float forwardSpeed = 1f, lateralSpeed = 1f;
    public float redCarpet, blueCarpet;
    public SpriteRenderer letter, body;
    public Sprite blueLetter, redLetter;
    public GameObject persuadedBar;
    public GameObject blueParticles, redParticles;
    public Team moveTo = Team.Red;


    private float percentage = 0;

    private void Awake()
    {
        persuadedBar.transform.localScale = new Vector2(0f, 1f);
        var randTeam = Random.value > 0.5 ? true : false;
        if (randTeam)
        {
            moveTo = Team.Red;
            persuadedBar.GetComponent<SpriteRenderer>().color = Color.blue;
            letter.sprite = redLetter;
        }
        else
        {
            moveTo = Team.Blue;
            persuadedBar.GetComponent<SpriteRenderer>().color = Color.red;
            letter.sprite = blueLetter;
        }
    }

    void Update()
    {
        var layer = (int)(transform.position.y * -100);
        body.sortingOrder = layer;
        letter.sortingOrder = layer - 1;

        transform.Translate(Vector3.left* forwardSpeed * Time.deltaTime);

        if(moveTo == Team.Red)
        {
            if(Mathf.Abs(transform.position.y - redCarpet) > 0.1f)
            {
                transform.Translate(Vector3.up * lateralSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.y - blueCarpet) > 0.1f)
            {
                transform.Translate(Vector3.down * lateralSpeed * Time.deltaTime);
            }
        }

    }

    public void BeingPersuaded(Team team)
    {
        if (moveTo != team)
        {
            percentage = percentage + 0.01f;
            persuadedBar.transform.localScale = new Vector2(percentage, 1f);

            if (percentage >= 1f)
            {
                percentage = 0f;
                persuadedBar.transform.localScale = new Vector2(percentage, 1f);

                if (moveTo == Team.Red)
                {
                    moveTo = Team.Blue;
                    persuadedBar.GetComponent<SpriteRenderer>().color = Color.red;
                    letter.sprite = blueLetter;
                }
                else
                {
                    moveTo = Team.Red;
                    persuadedBar.GetComponent<SpriteRenderer>().color = Color.blue;
                    letter.sprite = redLetter;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BlueZone"))
        {
            var vote = Instantiate(blueParticles, this.transform.position, Quaternion.identity) as GameObject;
            vote.GetComponent<ParticleSystem>().Play();
            GameObject.Find("PersuadeManager").GetComponent<PersuadeManager>().VoteBlue();
            Destroy(vote, 2f);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("RedZone"))
        {
            var vote = Instantiate(redParticles, this.transform.position, Quaternion.identity) as GameObject;
            vote.GetComponent<ParticleSystem>().Play();
            GameObject.Find("PersuadeManager").GetComponent<PersuadeManager>().VoteRed();
            Destroy(vote, 2f);
            Destroy(this.gameObject);
        }

    }
}
