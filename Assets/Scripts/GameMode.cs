using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static event Action<int> ScoreChanged = delegate { };

    //public static GameMode Instance { get; private set; }

    private int breadScore = 0;
    private int highscore = 0;

    private GameObject clickableObject;

    private Canvas canvas;

    [Tooltip("How much one click will add to the score in the beginning")]
    public int breadScoreModifier = 1;

    public GameObject badEnding;
    public GameObject goodEnding;
    public GameObject secretEnding;

    public int scoreToBeat = 10;

    private void Awake()
    {
        /*if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Multiple instances of game mode are not allowed
            Destroy(gameObject);
        }*/

        Clickable.ObjectClicked += updateScore;
        Timer.TimerElapsed += onTimerElapsed;

        Debug.Log("Game Mode is awake");

        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    private void updateScore()
    {
        breadScore += breadScoreModifier;
        ScoreChanged(breadScore);
        Debug.Log("Game object " + gameObject.name + " changed the score to " + breadScore);
    }

    private void onTimerElapsed()
    {
        Debug.Log("You made " + breadScore + " bread! Congrats, follow your dreams while you still can");
        clickableObject = GameObject.Find("ClickablePanel");
        clickableObject.SetActive(false);

        if (breadScore > highscore)
        {
            highscore = breadScore;
        }

        DisplayEnding();
    }

    private void DisplayEnding()
    {
        if (breadScore == 0)
        {
            secretEnding.SetActive(true);
        }
        else if (breadScore >= scoreToBeat)
        {
            goodEnding.SetActive(true);
        }
        else
        {
            badEnding.SetActive(true);
        }
    }

    private void OnDisable()
    {
        Clickable.ObjectClicked -= updateScore;
        Timer.TimerElapsed -= onTimerElapsed;
    }
}
