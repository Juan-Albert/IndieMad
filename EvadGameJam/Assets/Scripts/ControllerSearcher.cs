using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSearcher : MonoBehaviour
{
    public GameObject[] players;
    public GameObject startText;

    private bool[] playing = new bool[4];
    
    void Update()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                Debug.Log(vKey);

            }
        }

        float h = Input.GetAxis("HorizontalP1");
        float v = Input.GetAxis("VerticalP1");
        Debug.Log("Player 1: " + h + " " + v);

        h = Input.GetAxis("HorizontalP2");
        v = Input.GetAxis("VerticalP2");
        Debug.Log("Player 2: " + h + " " + v);

        h = Input.GetAxis("HorizontalP3");
        v = Input.GetAxis("VerticalP3");
        Debug.Log("Player 3: " + h + " " + v);

        bool action = Input.GetKeyDown(KeyCode.Joystick1Button1);
        Debug.Log("Player 1: " + action);

        action = Input.GetKeyDown(KeyCode.Joystick2Button1);
        Debug.Log("Player 2: " + action);

        action = Input.GetKeyDown(KeyCode.Joystick3Button1);
        Debug.Log("Player 3: " + action);

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
                GameManager.instance.CompleteLevel();
            }
        }
        else
        {
            startText.SetActive(false);
        }
    }
}
