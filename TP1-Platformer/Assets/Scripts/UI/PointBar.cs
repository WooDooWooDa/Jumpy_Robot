using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointText;

    public void UpdateScore(int score)
    {
        pointText.text = "Points :  " + score;
    }
}
