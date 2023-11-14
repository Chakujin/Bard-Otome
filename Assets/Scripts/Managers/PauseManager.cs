using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject m_PauseCanvas;
    private void Awake() 
    {
        //Singletone
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        m_PauseCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        m_PauseCanvas.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause()
    {
        m_PauseCanvas.SetActive(true);
        GameIsPaused = true;
    }
}
