using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] private GameObject m_MainMenu;
    [SerializeField] private GameObject m_Submenu;
    [SerializeField] private Image[] m_ButtonsBackround;

    private bool b_StartEffect = false;
    private float f_Fade = 0.3f;
    private float f_DelayTime = 1.5f;

    private void Start() 
    {
        m_Submenu.SetActive(false);
    }

    private void Update() 
    {
        if(b_StartEffect == true)
        {
            f_Fade -= Time.deltaTime / f_DelayTime;

            //Dissolve Effect on button array
            foreach(Image obj in m_ButtonsBackround)
            {
                obj.material.SetFloat("_Fade",f_Fade);
            }

            if(f_Fade <= -0.3)
            {
                //Restart the values
                b_StartEffect = false;
                f_Fade = 2;

                foreach(Image obj in m_ButtonsBackround)
                {
                    obj.material.SetFloat("_Fade",0.3f);
                }
                
                m_Submenu.SetActive(true);
                //Last (turn off the script)
                m_MainMenu.SetActive(false);
            }
        }
    }

    public void PressButton()
    {
        // Open pass Update
        b_StartEffect = true;
        
        // Alpha 0 text
        foreach(Image obj in m_ButtonsBackround)
        {
            TextMeshProUGUI textChild = obj.GetComponentInChildren<TextMeshProUGUI>();
            textChild.DOFade(0,0.5f);
        }
    }
}
