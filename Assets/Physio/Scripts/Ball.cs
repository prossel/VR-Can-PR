using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    static int nBalls = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

// trigger enter
    void OnTriggerEnter(Collider other)
    {
        nBalls++;
        Debug.Log("Number of balls in play: " + nBalls);
    }

    // trigger exit
    void OnTriggerExit(Collider other)
    {
        // decrement the number of balls in play
        --nBalls;
        Debug.Log("Number of balls in play: " + nBalls);

        // if there are no balls left in play
        if (nBalls <= 0)
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
