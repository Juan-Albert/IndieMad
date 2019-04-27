using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampManager : MonoBehaviour
{
    public GameObject envelope;
    public GameObject[] players;
    public SpriteRenderer[] Arms;
    public Sprite redArm, blueArm;

    private int redScore = 0;
    private int blueScore = 0;
    private bool keepCreating = true;
    private int layer = 10;

    void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(GameManager.instance.playing[i]);
            players[i].GetComponent<Stamp>().playerInfo = new PlayerInfo(i, GameManager.instance.playersTeam[i]);
            if (GameManager.instance.playersTeam[i] == Team.Blue)Arms[i].sprite = blueArm;
            else Arms[i].sprite = redArm;
        }
        StartCoroutine(Spawn());
        StartCoroutine(Timer());

    }

    public void RedStamp()
    {
        redScore++;
    }

    public void BlueStamp()
    {
        blueScore++;
    }

    IEnumerator Spawn()
    {
        while(keepCreating)
        {
            Vector2 spawnPos = Random.insideUnitCircle * 4;

            GameObject new_envelope = Instantiate(envelope, spawnPos + new Vector2(0f, 10f), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            new_envelope.GetComponent<Envelope>().start = true;
            new_envelope.GetComponent<Envelope>().target = spawnPos;
            new_envelope.GetComponent<SpriteRenderer>().sortingOrder = layer;
            layer+= 2;
            var rand = Random.Range(1f, 3f);
            yield return new WaitForSeconds(rand);

        }

    }

    IEnumerator Timer()
    {
        int time = 10;

        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
        }
        if (redScore > blueScore) GameManager.instance.redScore++;
        else if (blueScore > redScore) GameManager.instance.blueScore++;
        GameManager.instance.ChangeTeams();

    }
}
