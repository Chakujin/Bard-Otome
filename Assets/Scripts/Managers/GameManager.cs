using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public static GameManager instance;

    //Stats
    public string playerName;
    public int Wisdom;
    public int Inteligence;
    public int Constitution;
    public int Charisma;
    public int Dexterity;
    public int Strength;

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
    // IF YOU NEED SAVE/LOAD THE GAME USE DataPersistenceManager.LoadGame() or DataPersistenceManager.SaveGame()
    public void LoadData(GameData data)
    {
        this.playerName = data.playerName;
        this.Wisdom = data.Wisdom;
        this.Inteligence = data.Inteligence;
        this.Constitution = data.Constitution;
        this.Charisma = data.Charisma;
        this.Dexterity = data.Dexterity;
        this.Strength = data.Strength;
    }

    public void SaveData(ref GameData data)
    {
        data.playerName = playerName;
        data.Wisdom = Wisdom;
        data.Inteligence = Inteligence;
        data.Constitution = Constitution;
        data.Charisma = Charisma;
        data.Dexterity = Dexterity;
        data.Strength = Strength;
    }
}
