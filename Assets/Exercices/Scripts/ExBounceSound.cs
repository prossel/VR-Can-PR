using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Play a sound when a collision is detected
public class ExBounceSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect collision
    void OnCollisionEnter(Collision collision)
    {
        // Play a sound
        GetComponent<AudioSource>().Play();
    }
    
}
