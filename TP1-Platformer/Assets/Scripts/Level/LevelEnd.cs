using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private LayerMask computerLayer;
    [SerializeField] private UIMenu menu;
    [SerializeField] private int nextLevel;

    private float detectionRadius = 0.3f;

    void Update()
    {
        if (DetectComputer())
        {
            if (InteractInput())
            {
                Computer.Instance.TurnOn();
                menu.OnPlayerWin();
            }
        }
    }

    public void MoveToNextLevel()
    {
        //var activeSceneName = SceneManager.GetActiveScene().name;
        //var activeLevelNumber = activeSceneName.Substring(5, activeSceneName.Length - 5);
        //int activeLevel = int.Parse(activeLevelNumber);
        
        if (nextLevel == 0) {
            SceneManager.LoadScene("Menu");
        } else {
            PlayerPrefs.SetInt("levelReached", nextLevel);
            SceneManager.LoadScene("Level" + nextLevel);
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectComputer()
    {
        return Physics2D.OverlapCircle(Player.Instance.gameObject.transform.position, detectionRadius, computerLayer);
    }
}
