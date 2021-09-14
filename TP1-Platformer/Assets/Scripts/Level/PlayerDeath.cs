using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private UIMenu menu;

    void Update()
    {
        if (!Player.Instance.IsAlive())
        {
            menu.OnPlayerDeath();
        }
    }

}
