using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Blue, Red, None
}

[System.Serializable]
public class PlayerInfo 
{
    public int id;
    public Team team;

    public PlayerInfo(int newID, Team newTeam)
    {
        id = newID;
        team = newTeam;
    }
}
