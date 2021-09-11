using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask computerLayer;

    private float detectionRadius = 0.2f;

    void Update()
    {
        if (DetectComputer())
        {
            if (InteractInput())
            {
                Debug.Log("GAME END");
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectComputer()
    {
        return Physics2D.OverlapCircle(player.position, detectionRadius, computerLayer);
    }
}
