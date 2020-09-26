using UnityEngine;
using UnityEngine.UI;

/*
 * Timer that counts down from maxTime to 0.
 * Notifies when the timer ran out.
 */
public class Timer : MonoBehaviour
{
    private float currentTime = 0f;
    public float maxTime = 30f;

    public Text timerText;

    private void Start()
    {
        currentTime = maxTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = "0:" + currentTime.ToString("0");
        if (currentTime <= 0f)
        {
            timerText.text = "0:0";
        }
    }
}
