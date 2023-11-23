using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawner is a class that spawns various objects in the game
public class Spawner : MonoBehaviour
{
    // The object to spawn
    public GameObject spawnObject;

    // launch speed
    public float launchSpeed = 500;

    // random variation on launch speed
    public float launchSpeedVariation = 100;

    // spawn delay
    public float spawnDelay = 1;

    // spawn delay variation
    public float spawnDelayVariation = 0.5f;


    // random variation on horizontal direction
    public float horizontalDirectionVariation = 20;

    // random variation on vertical direction
    public float verticalDirectionVariation = 20;

    // next spawn time
    private float nextSpawnTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        // set the next spawn time to the current time plus the spawn delay
        nextSpawnTime = Time.time + spawnDelay + Random.Range(-spawnDelayVariation, spawnDelayVariation);
    }


    // Update is called once per frame
    void Update()
    {
        // if the spawn delay has passed spawn a new object
        if (Time.time > nextSpawnTime)
        {
            // spawn a new object
            Spawn();
        }


    }

    // Spawn is called to spawn a new object
    void Spawn()
    {
        // create a new object
        GameObject newObject = Instantiate(spawnObject, transform.position, transform.rotation);

        // randomly rotate the object
        newObject.transform.Rotate(
            Random.Range(-verticalDirectionVariation, verticalDirectionVariation),
            Random.Range(-horizontalDirectionVariation, horizontalDirectionVariation),
            0);

        // get the rigidbody of the new object
        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();

        // if the rigidbody exists
        if (rigidbody != null)
        {
            // launch the object along its forward direction
            rigidbody.AddForce(newObject.transform.forward * (launchSpeed + Random.Range(-launchSpeedVariation, launchSpeedVariation)));
        }

        // set the next spawn time to the current time plus the spawn delay
        nextSpawnTime = Time.time + spawnDelay + Random.Range(-spawnDelayVariation, spawnDelayVariation);
    }
}
