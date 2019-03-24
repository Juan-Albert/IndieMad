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
        for(int i = 0; i < players.Length; i++)
        {
            GameManager.instance.playersTeam[i] = Team.None;
            players[i].SetActive(GameManager.instance.playing[i]);
        }
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        int time = 10;

        while(time > 0)
        {
            timer.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
        GameManager.instance.NextBattle();
        
    }
}
