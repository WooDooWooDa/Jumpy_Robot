using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPause = false;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleGame();
        }
    }

    void ToggleGame()
    {
        pausePanel.SetActive(!isPause);
        if (!isPause) {
            Debug.Log("pause");
            PauseGame();
        } else {
            Debug.Log("Resume");
            ResumeGame();
        }
        isPause = !isPause;
    }

    void PauseGame()
    {
        
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
