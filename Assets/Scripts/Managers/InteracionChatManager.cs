using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using JetBrains.Annotations;

public class InteracionChatManager : MonoBehaviour
{
    private GameManager m_gameManager;
    //CanvasObjects
    [SerializeField] private Canvas m_mycanvas;
    [SerializeField] private TextMeshProUGUI m_text;
    [SerializeField] private Image m_imagePlayer;

    [SerializeField] private GameObject m_canvasNoReply;

    // Reply canvas
    [SerializeField] private GameObject m_canvasReply;
    [SerializeField] private GameObject m_mainCanvas;
    [SerializeField] private Button[] m_replyButtons;

    // Attributes
    [SerializeField] public InteractionScriptableObject m_currentInteraction;
    [SerializeField] private InteractionScriptableObject m_lastInteraction;
    private int i_currentText = 0;

    //Singletone
    public static InteracionChatManager instance;
    private void Awake() 
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        //Assing the main camera when change the scene
        m_mycanvas.worldCamera = Camera.main;

        // Reset Canvas
        m_mainCanvas.SetActive(false);
        m_canvasReply.SetActive(false);

        CheckIfHaveInteraction();
        
        // Singletone
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

    // This fuction is only called when start a new scene
    private void CheckIfHaveInteraction()
    {
        if(m_gameManager.haveInteraction == true)
        {
            m_gameManager.haveInteraction = false;
            m_currentInteraction = m_gameManager.interaction;
            m_mainCanvas.SetActive(true);
            MakeInteraction(m_currentInteraction);
        }
    }

    // THIS FUCTION IS CALLED WHEN PRESS TO CONTINUE THE INTERACTION O CALL A NEW INTERACTION
    public void MakeInteraction(InteractionScriptableObject interaction)
    {   
        Debug.Log("Make Interaction");
        // CAN'T REPLY THE INTERACTION
        if(interaction.canReply == false)
        {
            // IF IS THE SAME INTERACTION
            if(interaction == m_lastInteraction)
            {                         
                // CONTINUE READING THE INTERACTION TEXT
                if(interaction.interactionTexts.Length > i_currentText)
                {
                    m_text.text = interaction.interactionTexts[i_currentText];
                    i_currentText++;
                }
                // FINISH THE INTERACTION
                else
                {
                    i_currentText = 0;
                    m_canvasNoReply.SetActive(false);
                    m_mainCanvas.SetActive(false);
                }
            }
            // IF IS ANOTHER NEW INTERACTION
            else
            {
                m_canvasNoReply.SetActive(true);
                m_lastInteraction = interaction;

                //START THE INTERACTION
                m_text.text = interaction.interactionTexts[i_currentText];
                m_imagePlayer.sprite = interaction.characterInteraction;
                i_currentText++;
            }
        }
        // CAN REPLY THE INTERACTION
        else if (interaction.canReply == true)
        {
            // IF IS THE SAME INTERACTION
            if(interaction == m_lastInteraction)
            {
                // CONTINUE READING THE INTERACTION TEXT
                if(interaction.interactionTexts.Length > i_currentText)
                {
                    m_text.text = interaction.interactionTexts[i_currentText];
                    i_currentText++;
                }
                // FINISH THE INTERACTION
                else
                {
                    i_currentText = 0;
                    m_canvasReply.SetActive(false);
                    m_mainCanvas.SetActive(false);
                }
            }
            // IF IS ANOTHER NEW INTERACTION
            else
            {
                m_canvasReply.SetActive(true);
                m_lastInteraction = interaction;

                //START THE INTERACTION
                m_text.text = interaction.interactionTexts[i_currentText];
                m_imagePlayer.sprite = interaction.characterInteraction;
                i_currentText++;

                for(int i = 0; i < m_replyButtons.Length; i++)
                {
                    // Assing new text replys to the buttons
                    m_replyButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = interaction.replys[i];
                }
            }
        }
    }

    public void PressButton()
    {
        MakeInteraction(m_currentInteraction);
    }
}
