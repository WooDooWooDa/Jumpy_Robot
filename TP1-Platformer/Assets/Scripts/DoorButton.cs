using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private LayerMask playerLayer;

    private float detectionRadius = 0.5f;
    private Animator doorAnimator;
    private bool doorIsOpen = false;

    private void Start()
    {
        doorAnimator = door.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (DetectButton())
        {
            if (InteractInput() && !doorIsOpen)
            {
                doorIsOpen = true;
                doorAnimator.SetTrigger("OpenDoor");
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectButton()
    {
        return Physics2D.OverlapCircle(Player.Instance.gameObject.transform.position, detectionRadius, playerLayer);
    }
}
