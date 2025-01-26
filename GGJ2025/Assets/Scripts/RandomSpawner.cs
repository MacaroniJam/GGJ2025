using System;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject[] SpritesToSpawn;

    [SerializeField] private float SpawnIntervals;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandom",0f,SpawnIntervals);
    }

    // Update is called once per frame
    void SpawnRandom() {

        // Pick a random index from the array
        int randIndex = UnityEngine.Random.Range(0, SpritesToSpawn.Length);

        // Instantiate the random sprite at the spawner's position
        Instantiate(SpritesToSpawn[randIndex], transform.position, Quaternion.identity);
    }


}

