using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private LayerMask computerLayer;
    [SerializeField] private int nextLevel;

    private float detectionRadius = 0.2f;

    void Update()
    {
        if (DetectComputer())
        {
            if (InteractInput())
            {
                Computer.Instance.TurnOn();
                StartCoroutine(MoveToNextLevel());
            }
        }
    }

    IEnumerator MoveToNextLevel()
    {
        yield return new WaitForSeconds(3);
        if (nextLevel == 0) {
            SceneManager.LoadScene("Menu");
        } else {
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
