using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    // list of balls in play
    public static List<Ball> balls = new List<Ball>();

// trigger enter
    void OnTriggerEnter(Collider other)
    {
        // add this ball to the list
        balls.Add(this);

        // increment the number of balls in play
        Debug.Log("Number of balls in play: " + balls.Count);
    }

    // trigger exit
    void OnTriggerExit(Collider other)
    {
        // remove this ball from the list
        balls.Remove(this);

        // decrement the number of balls in play
        Debug.Log("Number of balls in play: " + balls.Count);

        // if there are no balls left in play
        if (balls.Count <= 0)
        {
            // log a message
            Debug.Log("Game Over!");

            // Reload the scene after 3 seconds
            Invoke("ReloadScene", 3);
        }

    }

    // reload the scene
    void ReloadScene()
    {
        // reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
