using UnityEngine;
using System;

public class GameMode : MonoBehaviour
{
    public static event Action<int> ScoreChanged = delegate { };

    private int breadScore = 0;

    [Tooltip("How much one click will add to the score in the beginning")]
    public int breadScoreModifier = 1;

    private void Awake()
    {
        Clickable.ObjectClicked += updateScore;
    }

    private void updateScore()
    {
        breadScore += breadScoreModifier;
        ScoreChanged(breadScore);
    }

    private void OnApplicationQuit()
    {
        Clickable.ObjectClicked -= updateScore;
    }
}
