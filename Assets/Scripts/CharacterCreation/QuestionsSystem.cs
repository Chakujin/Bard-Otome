using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionsSystem : MonoBehaviour
{
    private DataPersistenceManager m_dataPersistenceManager;
    //UI
    [SerializeField] private Button[] m_AnswerButton;

    //Question
    [SerializeField] private QuestionScriptableObject[] m_Questions;
    [SerializeField] private TextMeshProUGUI  m_QuestionText;

    private int i_CurrentCuestion = 0;
    private int i_TotalCuestions = 0;
    // Start is called before the first frame update
    void Start()
    {   
        m_dataPersistenceManager = GameObject.FindGameObjectWithTag("DataPersistence").GetComponent<DataPersistenceManager>();

        //Print Firts Question
        i_TotalCuestions = m_Questions.Length;
        QuestionUpdate();
    }

    public void PressButton(GameObject obj)
    {
        obj.GetComponent<ButtonUpdateSkill>().SkillUpdate();
    }

    private void QuestionUpdate()
    {  
       if(i_CurrentCuestion < i_TotalCuestions)
        {
            // Change the question title
            m_QuestionText.text = m_Questions[i_CurrentCuestion].QuestionsDescription;

            for(int i = 0; i < m_Questions[i_CurrentCuestion].Answers.Length; i++)
            {
                // Put the Answers Scriptable Object from the Question Scriptable Object to the buttons
                m_AnswerButton[i].GetComponent<ButtonUpdateSkill>().answerObj = m_Questions[i_CurrentCuestion].Answers[i];
                m_AnswerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = m_Questions[i_CurrentCuestion].Answers[i].description;
            }
            i_CurrentCuestion++;
        }
        else
        {
            m_dataPersistenceManager.SaveGame();
            SceneManager.LoadScene("QuestSelect");
        }
    }
}
