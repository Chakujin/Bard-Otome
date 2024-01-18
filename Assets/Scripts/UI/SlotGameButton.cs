using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotGameButton : MonoBehaviour
{
    [SerializeField] private string s_SceneName;
    private DataPersistenceManager m_dataPersistenceManager;

    private void Start() 
    {
        m_dataPersistenceManager = GameObject.FindGameObjectWithTag("DataPersistence").GetComponent<DataPersistenceManager>();
    }

    public void StartGame()
    {
        m_dataPersistenceManager.LoadGame();
        SceneManager.LoadScene(s_SceneName);
    }
}
