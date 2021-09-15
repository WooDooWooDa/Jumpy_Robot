using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    private bool isFollowingPlayer = false;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 6.5f, -10f);
    }


    void Update()
    {
        if (isFollowingPlayer) {
            transform.position = new Vector3(player.position.x, Player.Instance.gameObject.transform.position.y + offset.y, player.position.z + offset.z);
        } else {
            transform.position = new Vector3(player.position.x, offset.y, player.position.z + offset.z);
        }
        
    }

    public void IsFollowingPlayer(bool value)
    {
        isFollowingPlayer = value;
    }
}
