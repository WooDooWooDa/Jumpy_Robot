using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int health = 5;
    public Text healthText;

    // Update is called once per frame
    void FixedUpdate()
    {
        healthText.text = "VIE : " + Heart();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }

    string Heart()
    {
        string heartString = "";
        for (int i = 0; i < health; i++)
        {
            heartString += '\u2661' + " ";
            Debug.Log("added heart");
        }
        Debug.Log("end");
        return heartString;
    }
}
