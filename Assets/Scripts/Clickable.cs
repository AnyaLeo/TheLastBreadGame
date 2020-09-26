using System;
using UnityEngine;

/**
 * An object that can be clicked on.
 * Handles the UI in relation to the clicked object.
 */
public class Clickable : MonoBehaviour
{
    public static event Action ObjectClicked = delegate { };

    public GameObject floatingTextPrefab;

    public void OnObjectClicked()
    {
        ObjectClicked();
        spawnUIAtPosition(Input.mousePosition);
    }

    private void spawnUIAtPosition(Vector2 position)
    {
        if (floatingTextPrefab != null)
        {
            GameObject instance = Instantiate(floatingTextPrefab);
            instance.transform.SetParent(transform, false);
            instance.transform.position = position;
            Debug.Log(position);
        }
    }
}
