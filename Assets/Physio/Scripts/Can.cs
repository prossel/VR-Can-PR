using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Can : MonoBehaviour
{

    // List of Material for the cans
    public Material[] materials;

    // list of all the cans
    public static List<Can> cans = new List<Can>();
    
    private void OnEnable()
    {
        // add this can to the list
        cans.Add(this);

        // random rotation on y axis
        transform.Rotate(0, Random.Range(0, 360), 0);

        // random material
        GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
    }

    private void OnDisable()
    {
        // remove this can from the list
        cans.Remove(this);
    }

    // has fallen
    public bool hasFallen()
    {
        // A can has fallen if its local y position is less than 0 (below the table) 
        // or the angle between its up vector and the world up vector is greater than 10 degrees
        return transform.localPosition.y < 0 || Vector3.Angle(transform.up, Vector3.up) > 10;
    }
}
