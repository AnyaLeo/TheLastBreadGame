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
        textDisplay.text = monologue[monologueIndex];
        monologueIndex++;
    }

    private void CheckIfMonologueEnded()
    {
        if (monologueIndex >= monologue.Length)
        {
            isMonologueRunning = false;
            MonologueEnded();
        }
    }
}
