using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<bool> playing;
    public int playersCount;
    public List<Team> playersTeam;
    public List<int> levels;

    public int teamRedPuntuation = 0;
    public int teamBluePuntuation = 0;

    public static GameManager instance = null;

    private List<int> tempLevels;

    private void Awake()
    {
        if (GameManager.instance == null) GameManager.instance = this;
        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        InstanciateGame();
    }

    public void ResetGame()
    {
        teamBluePuntuation = 0;
        teamRedPuntuation = 0;
        InstanciateGame();
        SceneManager.LoadScene("SelectController");
    }

    public void ChangeTeams()
    {
        SceneManager.LoadScene("Team Chooser");
    }

    public void NextBattle()
    {
        if(tempLevels.Count > 0)
        {
            var rand = Random.Range(0, tempLevels.Count - 1);

            var level = tempLevels[rand];
            tempLevels.RemoveAt(rand);
            SceneManager.LoadScene(level);
        }
        //Aqui jefe final
    }

    private void InstanciateGame()
    {
        playing.Clear();
        playersTeam.Clear();

        playing = new List<bool>();
        playersTeam = new List<Team>();
        for (int i = 0; i < 4; i++)
        {
            playing.Add(false);
            playersTeam.Add(Team.None);
        }
    }

    private void SelectLevels()
    {
        tempLevels.Clear();
        var levelsToSelect = levels;
        for(int i = 0; i < 0; i++)
        {
            var rand = Random.Range(0, levelsToSelect.Count - 1);
            tempLevels.Add(levelsToSelect[rand]);
            levelsToSelect.RemoveAt(rand);
        }
    }
}
