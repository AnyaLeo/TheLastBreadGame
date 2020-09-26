using System;
using UnityEngine;
using System.Collections;

/**
 * An object that can be clicked on.
 * Handles the UI in relation to the clicked object.
 */
public class Clickable : MonoBehaviour
{
    public static event Action ObjectClicked = delegate { };

    public GameObject floatingTextPrefab;
    public GameObject floatingBreadPrefab;

    public float breadPositionModifier = 1f;

    /*public float positionModifierMin = -0.5f;
    public float positionModifierMax = 0.5f;*/

    public float scaleModifierMin = 0.8f;
    public float scaleModifierMax = 1.5f;

    public void OnObjectClicked()
    {
        ObjectClicked();
        Vector2 mousePos = Input.mousePosition;

        Vector2 breadPosition = new Vector2(
            mousePos.x + UnityEngine.Random.Range(-breadPositionModifier, breadPositionModifier),
            mousePos.y + UnityEngine.Random.Range(-breadPositionModifier, breadPositionModifier));

        spawnUIAtPosition(floatingBreadPrefab, mousePos);
        //spawnUIAtPosition(floatingTextPrefab, mousePos);
    }

    private void spawnUIAtPosition(GameObject prefab, Vector2 position)
    {
        if (prefab != null)
        {
            GameObject instance = Instantiate(prefab);
            instance.transform.SetParent(transform, false);

            float scale = UnityEngine.Random.Range(scaleModifierMin, scaleModifierMax);
            instance.transform.localScale = new Vector3(scale, scale, scale);

            float positionModifier = UnityEngine.Random.Range(-breadPositionModifier, breadPositionModifier);
            instance.transform.position = new Vector2(position.x + positionModifier, position.y + positionModifier);
        }
    }
}
