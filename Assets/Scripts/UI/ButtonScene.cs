using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonScene : MonoBehaviour
{
    [SerializeField] private GameObject m_Submenu;
    [SerializeField] private GameObject[] m_Buttons;

    private void Start() 
    {
        m_Submenu.SetActive(false);
    }

    public void PressButton()
    {
        //Effecto desaparecer sprites

        foreach(GameObject obj in m_Buttons)
        {
            //Image img = obj.GetComponent<Image>();
        }

        m_Submenu.SetActive(true);

    }
}
