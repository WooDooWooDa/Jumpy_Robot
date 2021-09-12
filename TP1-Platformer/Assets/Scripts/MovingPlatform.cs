using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float movingSpeed = 3f;
    private int target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, movingSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (transform.position == waypoints[target].position) {
            if (target == waypoints.Count - 1) {
                target = 0;
            } else {
                target++;
            }
        }
    }
}
