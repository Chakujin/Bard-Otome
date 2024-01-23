using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Player things
    public string playerName;
    public int Wisdom;
    public int Inteligence;
    public int Constitution;
    public int Charisma;
    public int Dexterity;
    public int Strength;

    // Quest
    public List<QuestScriptableObject> Quest;
    public Object currentScene;

    // Interactions
    public bool haveInteraction;
    public InteractionScriptableObject interaction;

    // The values defined in this constructor will be the default values
    // The game starts with there's no data to Load
    public GameData()
    {
        // ATTRIBUTES
        this.playerName = "EmptyName";
        this.Wisdom = 1;
        this.Inteligence = 1;
        this.Constitution = 1;
        this.Charisma = 1;
        this.Dexterity = 1;
        this.Strength = 1;

        // QUEST
        this.Quest = null;
        this.currentScene = null;

        // INTERACTION
        this.haveInteraction = false;
        this.interaction = null;
    }
}
