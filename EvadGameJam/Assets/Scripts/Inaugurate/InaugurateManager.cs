using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InaugurateManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] strenghtBars;
    public Transform[] ribbons;
    public Sprite[] redRibbon, blueRibbon;
    public SpriteRenderer[] Arms;
    public Sprite redArm, blueArm;

    private int blueCutted = 0, redCutted = 0;

    private void Start()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(GameManager.instance.playing[i]);
            ribbons[i].gameObject.SetActive(GameManager.instance.playing[i]);
            strenghtBars[i].gameObject.SetActive(GameManager.instance.playing[i]);
            players[i].GetComponent<ScissorsController>().playerInfo = new PlayerInfo(i, GameManager.instance.playersTeam[i]);
            if (GameManager.instance.playersTeam[i] == Team.Blue)
            {
                Arms[i].sprite = blueArm;
                foreach(Transform child in ribbons[i].transform)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().sprite = blueRibbon[0];
                }
                ribbons[i].Find("rib_01").gameObject.GetComponent<SpriteRenderer>().sprite = blueRibbon[1];
                ribbons[i].Find("rib_21").gameObject.GetComponent<SpriteRenderer>().sprite = blueRibbon[1];
            }
            else
            {
                Arms[i].sprite = redArm;
                foreach (Transform child in ribbons[i].transform)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().sprite = redRibbon[0];
                }
                ribbons[i].Find("rib_01").gameObject.GetComponent<SpriteRenderer>().sprite = redRibbon[1];
                ribbons[i].Find("rib_21").gameObject.GetComponent<SpriteRenderer>().sprite = redRibbon[1];
            }
        }
    }
}
