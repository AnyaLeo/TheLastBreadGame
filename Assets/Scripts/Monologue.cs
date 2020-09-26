using System;
using UnityEngine;
using UnityEngine.UI;

public class Monologue : MonoBehaviour
{
    public string[] monologue;
    public Text textDisplay;

    public static event Action MonologueEnded = delegate { };

    private bool isMonologueRunning;
    private int monologueIndex;

    private Image activeImage;

    private void Start()
    {
        StartMonologue();
    }

    private void Update()
    {
        if (isMonologueRunning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MonologueDisplayLine();
                CheckIfMonologueEnded();
            }
        }
    }

    public void StartMonologue()
    {
        monologueIndex = 0;
        isMonologueRunning = true;
        MonologueDisplayLine();
    }

    private void MonologueDisplayLine()
    {
        EraseCurrentMonologueInScene();

        if (monologueIndex < monologue.Length)
        {
            string line = monologue[monologueIndex];
            // If we want to display an image, it has to be present in the scene
            if (line.Contains("IMAGE:"))
            {
                string[] split = line.Split(':');
                line = split[1];
                Debug.Log("Image name is " + line);

                activeImage = GameObject.Find(line).GetComponent<Image>();
                if (activeImage != null)
                {
                    activeImage.enabled = true;
                }
                else
                {
                    Debug.Log("Monologue, MonologueDisplayLine():" +
                        "tried to display an image when no image is present in the scene");
                }
            }
            else // display text
            {
                textDisplay.text = monologue[monologueIndex];
            }
        }

        monologueIndex++;
    }

    private void EraseCurrentMonologueInScene()
    {
        if (activeImage != null)
        {
            activeImage.enabled = false;
            activeImage = null;
        }
        textDisplay.text = "";
    }

    private void CheckIfMonologueEnded()
    {
        if (monologueIndex > monologue.Length)
        {
            isMonologueRunning = false;
            MonologueEnded();
        }
    }
}
