using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public static GameManager instance;

    //Stats
    public string playerName;
    public int Wisdom = 1;
    public int Inteligence = 1;
    public int Constitution = 1;
    public int Charisma = 1;
    public int Dexterity = 1;
    public int Strength = 1;

    //Quest
    public List<QuestScriptableObject> Quest;
    public Object currentScene;

    //Interaction
    public bool haveInteraction = false;
    public InteractionScriptableObject interaction;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    // THIS FUCTIONS ONLY NEED TO BE CALLED BY THE DataPersistenceManager
    // ONLY USE TO ADD ALL DATA TO BE SAVED/LOADED
    // IF YOU NEED SAVE/LOAD ON THE GAME USE DataPersistenceManager.LoadGame() or DataPersistenceManager.SaveGame()
    public void LoadData(GameData data)
    {
        //  ATTRIBUTES
        this.playerName = data.playerName;
        this.Wisdom = data.Wisdom;
        this.Inteligence = data.Inteligence;
        this.Constitution = data.Constitution;
        this.Charisma = data.Charisma;
        this.Dexterity = data.Dexterity;
        this.Strength = data.Strength;

        // QUEST
        //this.Quest = data.Quest;
        this.currentScene = data.currentScene;

        // INTERACTION
        this.haveInteraction = data.haveInteraction;
        this.interaction = data.interaction;
    }

    public void SaveData(ref GameData data)
    {
        // ATTRIBUTES
        data.playerName = playerName;
        data.Wisdom = Wisdom;
        data.Inteligence = Inteligence;
        data.Constitution = Constitution;
        data.Charisma = Charisma;
        data.Dexterity = Dexterity;
        data.Strength = Strength;

        // QUEST
        //data.Quest = Quest;
        data.currentScene = currentScene;

        // INTERACTION
        data.haveInteraction = haveInteraction;
        data.interaction = interaction;
    }
}
