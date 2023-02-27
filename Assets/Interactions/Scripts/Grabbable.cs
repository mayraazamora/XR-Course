using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public Color touchedColour;

    private Color initialColour;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // Store the initial color of the object
        initialColour = GetComponent<Renderer>().material.color;

        // Store the rigid body of the object 
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnTouched(Grabber grabber)
    {
        // Change the color of the touched object to the touched color
        GetComponent<Renderer>().material.color = touchedColour;
    }

    public void OnUntouched(Grabber grabber)
    {
        // Change the color of the object back to the initial color
        GetComponent<Renderer>().material.color = initialColour;
    }

    public virtual void OnGrab(Grabber grabber)
    {
        // Child this object to the grabber
        transform.SetParent(grabber.transform);

        // Turn off physics
        rigidBody.useGravity = false;
        rigidBody.isKinematic = true;
    }

    public virtual  void OnDrop()
    {
        // Unparent the object 
        transform.SetParent(null);

        // Turn on physics 
        rigidBody.useGravity = true;
        rigidBody.isKinematic = false;
    }

    public virtual void OnTriggerStart()
    {

    }

    public virtual void OnTriggerEnd()
    {

    }
}
