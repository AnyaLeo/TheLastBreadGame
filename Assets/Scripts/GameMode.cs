using UnityEngine;
using System;

public class GameMode : MonoBehaviour
{
    public static event Action<int> ScoreChanged = delegate { };

    private int breadScore = 0;

    [Tooltip("How much one click will add to the score in the beginning")]
    public int breadScoreModifier = 1;

    public GameObject clickableObject;

    private void Awake()
    {
        Clickable.ObjectClicked += updateScore;
        Timer.TimerElapsed += onTimerElapsed;
    }

    private void updateScore()
    {
        breadScore += breadScoreModifier;
        ScoreChanged(breadScore);
    }

    private void onTimerElapsed()
    {
        Debug.Log("You made " + breadScore + " bread! Congrats, follow your dreams while you still can");
        clickableObject.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        Clickable.ObjectClicked -= updateScore;
        Timer.TimerElapsed -= onTimerElapsed;
    }
}
