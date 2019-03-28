using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TeamChooser : MonoBehaviour
{
    public Text timer;
    public GameObject[] players;

    private void Awake()
    {
        for(int i = 0; i < GameManager.instance.playersCount; i++)
        {
            GameManager.instance.playersTeam[i] = Team.None;
            players[i].SetActive(GameManager.instance.playing[i]);
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        int time = 10;
        timer.text = time.ToString();

        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time--;
            timer.text = time.ToString();
        }

        for (int i = 0; i < players.Length; i++)
        {
           if(players[i].activeInHierarchy) GameManager.instance.playersTeam[i] = players[i].GetComponent<PlayerMovement>().playerInfo.team;
        }
        GameManager.instance.NextBattle();
        
    }
}
