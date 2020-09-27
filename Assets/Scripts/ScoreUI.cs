using UnityEngine;
using UnityEngine.UI;

/*
 * Score keeps track of the UI element Score
 */
public class ScoreUI : MonoBehaviour
{
    private Text ScoreUIText;

    private void Awake()
    {
        GameMode.ScoreChanged += OnScoreChanged;
        ScoreUIText = GetComponent<Text>();
    }

    private void OnScoreChanged(int newScore)
    {
        ScoreUIText.text = newScore.ToString();
    }

    private void OnDisable()
    {
        GameMode.ScoreChanged -= OnScoreChanged;
    }
}
