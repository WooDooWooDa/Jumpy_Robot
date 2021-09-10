using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private int[,] resolutions = new int[4, 2] { { 800, 600 }, { 1920, 1080 }, { 2560, 1440 }, { 3840, 2160 } };
    [SerializeField] private TextMeshProUGUI fullScreenText;
    
    private bool _fullscreen;
    private int _screenWidth;
    private int _screenHeight;

    private void Start()
    {
        _fullscreen = false;
        fullScreenText.text = "NO";
    }

    public void ChangeResolution(int width, int height)
    {
        _screenWidth = width;
        _screenHeight = height;
    }

    public void ToggleFullScreen()
    {
        _fullscreen = !_fullscreen;
        fullScreenText.text = _fullscreen ? "YES" : "NO";
        Screen.SetResolution(_screenWidth, _screenHeight, _fullscreen);
    }
}
