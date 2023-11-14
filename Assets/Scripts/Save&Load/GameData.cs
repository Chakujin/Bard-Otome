using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string playerName;

    // The values defined in this constructor will be the default values
    // The game starts with there's no data to Load
    public GameData()
    {
        this.playerName = "EmptyName";
    }
}
