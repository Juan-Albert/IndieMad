using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersuadeManager : MonoBehaviour
{
    public GameObject npcZombie;
    public GameObject[] voterRedSpawns, voterBlueSpawns;
    public GameObject[] players;
    public SpriteRenderer[] playersBody;
    public Sprite blueSuit, redSuit;


    private int bluePoints = 0, redPoints = 0;
    private int roundPoints = 0;

    private void Start()
    {
        for (int i = 0; i < GameManager.instance.playersCount; i++)
        {
            players[i].SetActive(GameManager.instance.playing[i]);
            players[i].GetComponent<PlayerMovement>().playerInfo = new PlayerInfo(i, GameManager.instance.playersTeam[i]);
            if (GameManager.instance.playersTeam[i] == Team.Blue) playersBody[i].sprite = blueSuit;
            else playersBody[i].sprite = redSuit;
        }
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        //GameManager.instance.ChangeTeams();

    }
}
