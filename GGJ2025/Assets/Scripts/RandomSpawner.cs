using System;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    [SerializeField] private GameObject rock1;

    [SerializeField] private float spawn_rate;
    [SerializeField] private float timer;

     void Start() {

        Instantiate(rock1, transform.position, transform.rotation);
    }

     void Update() {

        if (timer < spawn_rate) {

            timer = timer + Time.deltaTime;
        } else {

            Instantiate(rock1, transform.position, transform.rotation);
            timer = 0;
        }
    }


}

