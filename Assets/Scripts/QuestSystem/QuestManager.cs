using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    // Managers
    private DataPersistenceManager m_dataPersistenceManager;
    private GameManager m_gameManager;

    // System
    private List<QuestScriptableObject> m_quest;
    [SerializeField] private GameObject[] m_ButtonsQuest;

    private void Awake()
    {
        m_dataPersistenceManager = GameObject.FindGameObjectWithTag("DataPersistence").GetComponent<DataPersistenceManager>();
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_quest = m_gameManager.Quest;
    }

    public void QuestButtonPressed()
    {

    }
}
