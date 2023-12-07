using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Can : MonoBehaviour
{

    // the starting position of the can
    public Vector3 startingPosition;

    // the starting rotation of the can
    public Quaternion startingRotation;


    // list of all the cans
    public static List<Can> cans = new List<Can>();

    
    private void OnEnable()
    {
        // add this can to the list
        cans.Add(this);
    }

    private void OnDisable()
    {
        // remove this can from the list
        cans.Remove(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        // remember the starting position and rotation
        startingPosition = transform.position;
        startingRotation = transform.rotation;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // has fallen
    public bool hasFallen()
    {
        // A can has fallen if its local y position is less than 0 (below the table) 
        // or the angle between its up vector and the world up vector is greater than 10 degrees
        return transform.localPosition.y < 0 || Vector3.Angle(transform.up, Vector3.up) > 10;
    }
}
