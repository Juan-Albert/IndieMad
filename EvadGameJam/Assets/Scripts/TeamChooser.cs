using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TeamChooser : MonoBehaviour
{
    public Text timer;
    public GameObject[] players;
    
    private bool timeUp = false;

    private void Awake()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(GameManager.instance.playing[i]);
            
        }
    }

    private void Update()
    {
        
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
        
        timeUp = true;
    }
}
