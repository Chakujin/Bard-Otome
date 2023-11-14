using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionDropdown : MonoBehaviour
{
    private Resolution[] m_Resolutions;

    [SerializeField] private TMP_Dropdown m_Dropdown;

    // Start is called before the first frame update
    void Start()
    {
        m_Resolutions = Screen.resolutions;

        m_Dropdown.ClearOptions();

        List<string> options = new List<string>();

        for(int i = 0; i< m_Resolutions.Length; i++)
        {
            string myoption = m_Resolutions[i].width + "X" + m_Resolutions[i].height;
            options.Add(myoption);
        }
        m_Dropdown.AddOptions(options);
    }
}
