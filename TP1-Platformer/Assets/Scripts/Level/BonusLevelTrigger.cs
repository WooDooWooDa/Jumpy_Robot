using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelTrigger : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mainCamera.GetComponent<CameraMovement>().IsFollowingPlayer(true);
    }
}
