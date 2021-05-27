using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddyBringer : MonoBehaviour
{
    public GameObject[] baddyPrefabs;

    private float baddyBirth = 8.0f;
    void Start()
    {
        InvokeRepeating("BringEmIn", 3.0f, 1.5f);
    }

    // Update is called once per frame
    void BringEmIn()
    {
        int baddyPrefabsIndex = Random.Range(0, baddyPrefabs.Length);
        Instantiate(baddyPrefabs[baddyPrefabsIndex],GenerateSpawnPosition(), baddyPrefabs[baddyPrefabsIndex].transform.rotation);
    }
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-baddyBirth, baddyBirth);
        float zPos = Random.Range(-baddyBirth, baddyBirth);
        Vector3 spawnPos = new Vector3(xPos, 0, zPos);
        return spawnPos;
    }
}
