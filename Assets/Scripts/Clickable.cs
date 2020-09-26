using System;
using UnityEngine;

/**
 * An object that can be clicked on.
 *
 */
public class Clickable : MonoBehaviour
{
    public static event Action ObjectClicked = delegate { };

    public void OnObjectClicked()
    {
        ObjectClicked();
    }
}
