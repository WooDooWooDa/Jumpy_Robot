using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 6.5f, -10f);
    }


    void Update()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z + offset.z);
    }
}
