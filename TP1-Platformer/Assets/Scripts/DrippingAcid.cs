using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DrippingAcid : MonoBehaviour
{
    [SerializeField] private GameObject dropletPrefab;

    private float timer = 2f;
    private float maxTimerValue = 1f;

    void Start()
    {
        timer = maxTimerValue;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            var droplet = Instantiate(dropletPrefab, new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y, transform.position.z), transform.rotation);
            Destroy(droplet, 3);
            timer = maxTimerValue + Random.Range(-0.2f, 1f);
        }
    }
}
