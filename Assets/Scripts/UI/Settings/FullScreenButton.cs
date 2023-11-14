using UnityEngine;

public class FullScreenButton : MonoBehaviour
{
    public void FullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
