using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // last fallen cans count
    int lastFallenCansCount = 0;

    // points TMPro text
    public TMPro.TMP_Text pointsText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            CountPoints();
        }

        // throw a ball on mouse click
        if (Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
    }

    // count points
    void CountPoints()
    {
        // count the number of cans that have fallen
        int fallenCans = 0;
        foreach (Can can in Can.cans)
        {
            if (can.hasFallen())
            {
                fallenCans++;
            }
        }

        // if fallen cans count has changed
        if (fallenCans != lastFallenCansCount)
        {
            // Display points
            pointsText.text = fallenCans + "";

            // log the number of fallen cans
            Debug.Log("Fallen cans: " + fallenCans);

            // update the last fallen cans count
            lastFallenCansCount = fallenCans;
        }
    }

    // throw a ball
    void ThrowBall()
    {
        // get one available ball from the list
        if (Ball.balls.Count <= 0)
        {
            return;
        }
        GameObject ball = Ball.balls[0].gameObject;

        // set the ball's position to the camera's position
        ball.transform.position = Camera.main.transform.position;

        // get the rigidbody component
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Calculate the force to apply to the ball. 
        // Mouse position is used to determine the force direction.
        // Default direction is the camera's forward vector when the mouse in at the center of the screeen.
        Vector3 direction = Camera.main.transform.forward;

        // Get the mouse position
        Vector3 mousePosition = Input.mousePosition;
        Debug.Log("Mouse position: " + mousePosition);

        // Get the screen width and height
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Debug.Log("Screen width: " + screenWidth);
        Debug.Log("Screen height: " + screenHeight);
    
        // Rotate direction around x axis based on relative mouse position on the screen
        float xRotation =  (mousePosition.y - screenHeight / 2) / screenHeight * -90f;
        direction = Quaternion.AngleAxis(xRotation, Vector3.right) * direction;
        float yRotation = (mousePosition.x - screenWidth / 2) / screenWidth * 90f;
        direction = Quaternion.AngleAxis(yRotation, Vector3.up) * direction;
        

        // Normalize the direction
        direction.Normalize();

        Debug.Log("Direction: " + direction);

        // Apply a force to the ball
        rb.AddForce(direction * 500f);


        // apply a force to the ball
        //rb.AddForce(Camera.main.transform.forward * 500f);
    }

}
