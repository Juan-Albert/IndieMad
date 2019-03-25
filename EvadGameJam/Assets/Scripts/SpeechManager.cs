using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{

    public Text timer;
    public GameObject speakerBlue, speakerRed;



    IEnumerator Timer()
    {
        int time = 10;

        while (time > 0)
        {
            timer.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time--;
        }
        GameManager.instance.NextBattle();

    }
}
