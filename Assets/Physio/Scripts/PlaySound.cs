using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlaySound is a class that plays a sound when an event occurs on the object
public class PlaySound : MonoBehaviour
{
    public AudioClip[] clips;

    public bool PlayOnCollisionEnter = false;
    public bool PlayOnCollisionExit = false;
    public bool PlayOnTriggerEnter = false;
    public bool PlayOnTriggerExit = false;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // detect collision
    void OnCollisionEnter(Collision collision)
    {
        // if we should play on collision enter
        if (PlayOnCollisionEnter)
        {
            // play a random clip
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }

    // detect collision exit
    void OnCollisionExit(Collision collision)
    {
        // if we should play on collision exit
        if (PlayOnCollisionExit)
        {
            // play a random clip
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }

    // detect trigger enter
    void OnTriggerEnter(Collider other)
    {
        // if we should play on trigger enter
        if (PlayOnTriggerEnter)
        {
            // play a random clip
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }

    // detect trigger exit
    void OnTriggerExit(Collider other)
    {
        // if we should play on trigger exit
        if (PlayOnTriggerExit)
        {
            // play a random clip
            audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }



}
