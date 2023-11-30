using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // collision detection
    void OnCollisionEnter(Collision collision)
    {
        // log the collided object name
        Debug.Log("Collided with " + collision.gameObject.name, collision.gameObject);

        // destroy this object
        Destroy(gameObject);
    }
}
