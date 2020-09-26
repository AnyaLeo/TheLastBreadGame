using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float secondsBetweenSpawn = 2;
    public GameObject spawnPrefab;

    private float spawnerWidth;
    private float spawnerHeight;
    private float spawnerXPos;
    private float spawnerYPos;

   // private GameObject[] currentSpawns;

    // Start is called before the first frame update
    void Start()
    {
        spawnerWidth = GetComponent<RectTransform>().sizeDelta.x;
        spawnerHeight = GetComponent<RectTransform>().sizeDelta.y;
        spawnerXPos = GetComponent<RectTransform>().transform.position.x;
        spawnerYPos = GetComponent<RectTransform>().transform.position.y;

        InvokeRepeating("SpawnObject", secondsBetweenSpawn, secondsBetweenSpawn);
        Debug.Log(spawnerWidth + " " + spawnerHeight);
    }

    private void SpawnObject()
    {
        GameObject instance = Instantiate(spawnPrefab);

        // Position the spawned object within the dimensions of the spawner
        Vector2 newPos = new Vector2(Random.Range(0, spawnerWidth), Random.Range(0, spawnerHeight));
        instance.transform.position = newPos;

        float scale = Random.Range(1f, 2.5f);
        instance.transform.localScale = new Vector3(scale, scale, scale);

        Debug.Log(newPos);
        instance.transform.SetParent(this.transform);
        //currentSpawns[currentSpawns.Length - 1] = instance;
    }
}
