using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;

    private bool isPause = false;

    private void Awake()
    {
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleGame();
        }
    }
    
    public void OnPlayerWin()
    {
        winPanel.SetActive(true);
        StartCoroutine(PauseIn(3));
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
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        deathPanel.SetActive(false);
        winPanel.SetActive(false);
        isPause = false;
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

    IEnumerator PauseIn(int sec)
    {
        yield return new WaitForSeconds(sec);
        PauseGame();
    }
}
