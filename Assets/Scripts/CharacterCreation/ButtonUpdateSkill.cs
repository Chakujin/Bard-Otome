using UnityEngine;

public class ButtonUpdateSkill : MonoBehaviour
{
    private GameManager m_gameManager;
    public AnswersScriptableObject answerObj;

    private void Awake() 
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();    
    }
    public void SkillUpdate()
    {
        answerObj.AddStats(m_gameManager);
    }
}
