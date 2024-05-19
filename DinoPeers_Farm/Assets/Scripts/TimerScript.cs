using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text CountdownTimer;

    float gameTimer = 1200f;

    // Update is called once per frame
    void Update()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;

            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            CountdownTimer.text = timerString;
        }
        else
        {
            gameTimer = 0;
            CountdownTimer.text = "00:00";
        }
    }
}
