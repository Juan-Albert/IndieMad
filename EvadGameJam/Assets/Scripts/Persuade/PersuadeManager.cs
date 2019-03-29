using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersuadeManager : MonoBehaviour
{
    public int npcNumber = 7;
    public GameObject npcZombie;
    public Transform npcSpawn;
    public GameObject[] players;
    public SpriteRenderer[] playersBody;
    public Sprite blueSuit, redSuit;

    private int bluePoints = 0, redPoints = 0;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(10, 11);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(GameManager.instance.playing[i]);
            players[i].GetComponent<Persuade>().playerInfo = new PlayerInfo(i, GameManager.instance.playersTeam[i]);
            if (GameManager.instance.playersTeam[i] == Team.Blue) playersBody[i].sprite = blueSuit;
            else playersBody[i].sprite = redSuit;
        }
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if(bluePoints + redPoints >= npcNumber)
        {
            if (bluePoints > redPoints) GameManager.instance.teamBluePuntuation++;
            else GameManager.instance.teamRedPuntuation++;
            GameManager.instance.ChangeTeams();
        }
    }

    public void VoteBlue()
    {
        bluePoints++;
    }

    public void VoteRed()
    {
        redPoints++;
    }

    IEnumerator Spawn()
    {
        
        for(int i = 0; i < npcNumber; i++)
        {
            Instantiate(npcZombie, npcSpawn.position, Quaternion.identity);
            var randSpawnTime = Random.Range(1f, 4f);
            yield return new WaitForSeconds(randSpawnTime);

        }

    }
}
