using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public static event Action<int> ScoreChanged = delegate { };

    public static GameMode Instance { get; private set; }

    static private int breadScore = 0;
    static private int highscore = 0;

    private GameObject clickableObject;

    private Canvas canvas;

    [Tooltip("How much one click will add to the score in the beginning")]
    public int breadScoreModifier = 1;

    public GameObject badEnding;
    public GameObject goodEnding;

    public int scoreToBeat = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Multiple instances of Level Loader are not allowed
            Destroy(gameObject);
        }

        Clickable.ObjectClicked += updateScore;
        Timer.TimerElapsed += onTimerElapsed;
        Monologue.MonologueEnded += OnMonologueEnded;

        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
    }

    private void updateScore()
    {
        breadScore += breadScoreModifier;
        ScoreChanged(breadScore);
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
        if (breadScore >= scoreToBeat)
        {
            GameObject instance = Instantiate(goodEnding);
            instance.transform.SetParent(canvas.transform, false);
        }
        else
        {
            GameObject instance = Instantiate(badEnding);
            instance.transform.SetParent(canvas.transform, false);
        }
    }

    private void OnMonologueEnded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LevelLoader.Instance.LoadNextScene();
        }
    }

    private void OnApplicationQuit()
    {
        Clickable.ObjectClicked -= updateScore;
        Timer.TimerElapsed -= onTimerElapsed;
        Monologue.MonologueEnded -= OnMonologueEnded;
    }
}
