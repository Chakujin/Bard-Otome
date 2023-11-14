using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject m_AudioCanvas;
    [SerializeField] private GameObject m_ResolutionCanvas;
    [SerializeField] private GameObject m_MainBUttonsCanvas;
    
    private void OnEnable() 
    {
        m_AudioCanvas.SetActive(false);
        m_ResolutionCanvas.SetActive(false);
        m_MainBUttonsCanvas.SetActive(true);
    }
    
    public void MainMenu()
    {
        //Save game
        SceneManager.LoadScene(0);
    }

    public void Audio()
    {
        m_AudioCanvas.SetActive(true);
        m_ResolutionCanvas.SetActive(false);
        m_MainBUttonsCanvas.SetActive(false);
    }

    public void Resolution()
    {
        m_AudioCanvas.SetActive(false);
        m_ResolutionCanvas.SetActive(true);
        m_MainBUttonsCanvas.SetActive(false);
    }

    public void Back()
    {
        m_AudioCanvas.SetActive(false);
        m_ResolutionCanvas.SetActive(false);
        m_MainBUttonsCanvas.SetActive(true);
    }
}
