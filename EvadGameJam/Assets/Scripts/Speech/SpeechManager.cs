using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    
    public Animator speakerBlue, speakerRed;
    public GameObject blueParticles, redParticles;
    public GameObject[] players;
    public SpriteRenderer[] playersBody;
    public Sprite blueSuit, redSuit;


    private int bluePoints = 0, redPoints = 0;
    private int roundPoints = 0;

    private void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(GameManager.instance.playing[i]);
            players[i].GetComponent<VoteController>().playerInfo = new PlayerInfo(i, GameManager.instance.playersTeam[i]);
            if (GameManager.instance.playersTeam[i] == Team.Blue) playersBody[i].sprite = blueSuit;
            else playersBody[i].sprite = redSuit;
        }
        StartCoroutine(Speech());
    }

    public void Cheer()
    {
        roundPoints++;
    }

    public void Hate()
    {
        roundPoints--;
    }

    IEnumerator Speech()
    {
        var randSpeaker = (Random.value > 0.5f);

        for(int i = 0; i < 4; i++)
        {
            if(randSpeaker)
            {
                speakerBlue.SetTrigger("Talk");
                blueParticles.SetActive(true);
            }
            else
            {
                speakerRed.SetTrigger("Talk");
                redParticles.SetActive(true);
            }
            var randSpeechTime = Random.Range(4f, 6f);
            yield return new WaitForSeconds(randSpeechTime);

            if(roundPoints >= 0)
            {
                if (randSpeaker)
                {
                    bluePoints++;
                    speakerBlue.SetTrigger("Positive");
                    blueParticles.SetActive(false);
                }
                else
                {
                    redPoints++;
                    speakerRed.SetTrigger("Positive");
                    redParticles.SetActive(false);
                }
            }
            else
            {
                if (randSpeaker)
                {
                    redPoints++;
                    speakerBlue.SetTrigger("Negative");
                    blueParticles.SetActive(false);
                }
                else
                {
                    bluePoints++;
                    speakerRed.SetTrigger("Negative");
                    redParticles.SetActive(false);
                }
            }
            randSpeaker = !randSpeaker;
            roundPoints = 0;
        }
        if (bluePoints > redPoints) GameManager.instance.blueScore++;
        else GameManager.instance.redScore++;
        GameManager.instance.ChangeTeams();

    }
}
