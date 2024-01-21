using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class QuestManager : MonoBehaviour
{
    // Managers
    private DataPersistenceManager m_dataPersistenceManager;
    private GameManager m_gameManager;

    // System
    [SerializeField] private GameObject[] m_ButtonsQuest;

    private void Awake()
    {
        m_dataPersistenceManager = GameObject.FindGameObjectWithTag("DataPersistence").GetComponent<DataPersistenceManager>();
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Active the buttons if you have less than 2 quests
        switch(m_gameManager.Quest.Count)
        {
            case 0:
                foreach(GameObject obj in m_ButtonsQuest)
                {
                    obj.SetActive(false);
                }
                Debug.Log("No quedan quest");
                break;
            case 1:
                foreach(GameObject obj in m_ButtonsQuest)
                {
                    obj.SetActive(false);
                }
                m_ButtonsQuest[0].SetActive(true);
                Debug.Log("Solo aparece 1 boton");
                break;

            case 2:
                m_ButtonsQuest[2].SetActive(false);
                Debug.Log("Solo se activan 2 botones");
                break;
            
            default:
                break;
        }

        for(int i = 0; i < m_ButtonsQuest.Length; i++)
        {
            // Assing the avalible quest to the button if is active
            if(m_ButtonsQuest[i].activeSelf == true)
            {
                m_ButtonsQuest[i].GetComponent<QuestButtonPlay>().myQuest = m_gameManager.Quest[i];   
            }
        }
    }

    public void QuestButtonPressed(GameObject Button)
    {
        SceneAsset scene = Button.GetComponent<QuestButtonPlay>().myQuest.questLevel;
        SceneManager.LoadScene(scene.name);
    }
}
