using UnityEngine;
using UnityEngine.UI;

/*
 * Score keeps track of the UI element Score
 */
public class ScoreUI : MonoBehaviour
{
    public Text ScoreUIText;

    private void Awake()
    {
        GameMode.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int newScore)
    {
        ScoreUIText.text = newScore.ToString();
    }
}
