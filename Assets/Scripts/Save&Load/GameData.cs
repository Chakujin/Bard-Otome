using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string playerName;
    public int Wisdom;
    public int Inteligence;
    public int Constitution;
    public int Charisma;
    public int Dexterity;
    public int Strength;

    public List<QuestScriptableObject> Quest;

    // The values defined in this constructor will be the default values
    // The game starts with there's no data to Load
    public GameData()
    {
        this.playerName = "EmptyName";
        this.Wisdom = 1;
        this.Inteligence = 1;
        this.Constitution = 1;
        this.Charisma = 1;
        this.Dexterity = 1;
        this.Strength = 1;

        this.Quest = null;
    }
}
