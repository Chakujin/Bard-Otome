using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolumeScript : MonoBehaviour
{
    //Audio
    [SerializeField] private Slider m_mainVolumeSlider;
    [SerializeField] private AudioMixer m_audioMixer;
    public string exposedParametrer;

    private void OnEnable() 
    {
        float val = 0;
        m_audioMixer.GetFloat(exposedParametrer,out val);   

        m_mainVolumeSlider.value = val; 
    }

    //Sound Voids
    public void SetVolume(float sliderValue)
    {
        m_audioMixer.SetFloat(exposedParametrer, sliderValue);
        if (sliderValue == 0)
        {
            m_audioMixer.SetFloat(exposedParametrer, -60);
        }
    }
}
