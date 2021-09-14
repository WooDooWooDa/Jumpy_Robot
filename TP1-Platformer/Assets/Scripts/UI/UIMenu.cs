using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;

    private bool isPause = false;

    private void Awake()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleGame();
        }
    }

    public void OnPlayerDeath()
    {
        PauseGame();
        deathPanel.SetActive(true);
    }

    void ToggleGame()
    {
        pausePanel.SetActive(!isPause);
        if (!isPause) {

            PauseGame();
        } else {
            ResumeGame();
        }
        isPause = !isPause;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
    }

    public void Restart()
    {
        ResumeGame();
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
