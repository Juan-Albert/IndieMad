using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSearcher : MonoBehaviour
{
    public GameObject[] players;
    public GameObject startText;

    private List<bool> playing;

    private void Awake()
    {
        playing = new List<bool>();

        for(int i = 0; i < 4; i++)
        {
            playing.Add(false);
        }
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            playing[0] = !playing[0];
            players[0].SetActive(playing[0]);
        }

        if (Input.GetKeyDown(KeyCode.Joystick2Button1))
        {
            playing[1] = !playing[1];
            players[1].SetActive(playing[1]);

        }

        if (Input.GetKeyDown(KeyCode.Joystick3Button1))
        {
            playing[2] = !playing[2];
            players[2].SetActive(playing[2]);

        }

        if (Input.GetKeyDown(KeyCode.Joystick4Button1))
        {
            playing[3] = !playing[3];
            players[3].SetActive(playing[3]);

        }

        int activePlayers = 0;

        foreach(var player in playing)
        {
            if (player == true) activePlayers++;
        }

        if(activePlayers >= 2)
        {
            startText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.JoystickButton9))
            {
                GameManager.instance.playing = playing;
                GameManager.instance.playersCount = activePlayers;
                GameManager.instance.ChangeTeams();
            }
        }
        else
        {
            startText.SetActive(false);
        }
    }
}
