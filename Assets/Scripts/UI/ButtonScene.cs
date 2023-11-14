using UnityEngine;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] private GameObject m_MainMenu;
    [SerializeField] private GameObject m_Submenu;
    [SerializeField] private Image[] m_ButtonsBackround;

    private bool b_StartEffect = false;
    private float f_Fade = 2;

    private void Start() 
    {
        m_Submenu.SetActive(false);
    }

    private void Update() 
    {
        if(b_StartEffect == true)
        {
            f_Fade -= Time.deltaTime;

            //Dissolve Effect on button array
            foreach(Image obj in m_ButtonsBackround)
            {
                obj.material.SetFloat("_Fade",f_Fade);
            }

            if(f_Fade <= 0)
            {
                //Restart the values
                b_StartEffect = false;
                f_Fade = 2;

                m_Submenu.SetActive(true);

                foreach(Image obj in m_ButtonsBackround)
                {
                    obj.material.SetFloat("_Fade",1);
                }
                
                //Last (turn off the script)
                m_MainMenu.SetActive(false);
            }
        }
    }

    public void PressButton()
    {
        // Open pass Update
        b_StartEffect = true;
    }
}
