using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int phealth = 100;

    private void Update()
    {
        if (phealth <= 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
