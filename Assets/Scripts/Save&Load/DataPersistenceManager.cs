using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;
    private GameData m_gameData;

    private List<IDataPersistence> dataPersistencesObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance{get; private set;}

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.LogError("Found more then one Data Persistence Manager in the scene.");
        }    
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.m_gameData = new GameData();
    }

    public void LoadGame()
    {
        // Load any saved data from a file using the data handler
        this.m_gameData = dataHandler.Load();

        // If no data can be Loaded, initialize to a new game
        if(this.m_gameData == null)
        {
            Debug.Log("No data found. Initializing data to defaults");
            NewGame();
        }

        // push the Loaded data to all other scripts thet need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(m_gameData);
        }
    }

    public void SaveGame()
    {
        // Pass the data to other scripts
        foreach(IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(ref m_gameData);
        }

        // Save that data to a file using the data handler
        dataHandler.Save(m_gameData);
    }

    private void OnApplicationQuit() 
    {
        SaveGame();    
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}
