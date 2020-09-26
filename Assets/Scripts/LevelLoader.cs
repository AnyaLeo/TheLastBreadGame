using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Singleton class to load levels.
 */ 
public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }

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
    }

    public void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
