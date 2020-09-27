using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameMode : MonoBehaviour
{
    private void Awake()
    {
        Monologue.MonologueEnded += OnMonologueEnded;
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
        Monologue.MonologueEnded -= OnMonologueEnded;
    }
}
