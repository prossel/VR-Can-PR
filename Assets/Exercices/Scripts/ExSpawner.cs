using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnDelay = 10;

    public float spawnForce = 500;

    public float randomHorizontalAngle = 10;
    public float randomVerticalAngle = 10;

    private float lastSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawnTime > spawnDelay)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        // Spawn an object
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation);

        // Rotate the object around the Y axis by a random angle between -10 and 10
        obj.transform.Rotate(
            Random.Range(-randomVerticalAngle, randomVerticalAngle),
            Random.Range(-randomHorizontalAngle, randomHorizontalAngle),
            0);

        // throw the object along its forward axis
        obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward * spawnForce);

        lastSpawnTime = Time.time;
    }
}
