using UnityEngine;
using UnityEngine.UI;
using System;

/*
 * Timer that counts down from maxTime to 0.
 * Notifies when the timer ran out.
 */
public class Timer : MonoBehaviour
{
    public static event Action TimerElapsed = delegate { };

    private float currentTime = 0f;
    public float maxTime = 30f;

    public Text timerText;

    private bool isTimerGoing;

    private void Start()
    {
        currentTime = maxTime;
        isTimerGoing = true;
    }

    private void Update()
    {
        if (isTimerGoing)
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = "0:" + currentTime.ToString("0");
            if(currentTime <= 5f)
            {
                timerText.color = Color.red;
            }

            if (currentTime <= 0f)
            {
                isTimerGoing = false;
                timerText.text = "0:0";
                TimerElapsed();
            }
        }
    }
}
