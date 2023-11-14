using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotGameButton : MonoBehaviour
{
    [SerializeField] private string s_SceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(s_SceneName);
    }
}
