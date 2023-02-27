using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectThrower : MonoBehaviour
{
    public string triggerButton;
    public Rigidbody[] objects;
    private Rigidbody heldObject;
    public float throwImpulse;

    void Update()
    {
        //Check if the hand trigger has been pressed
        if (Input.GetButtonDown(triggerButton))
        {
            //Choose random object to spawn 
            Rigidbody randomObject = objects[Random.Range(0, objects.Length)];

            //Spawn the object 
            heldObject = Instantiate(randomObject,transform.position,transform.rotation, transform);

            //Attach the object to the hand
            heldObject.useGravity = false;
            heldObject.isKinematic = true; 
        }

        //Check if the hand trigger has been released
        if (Input.GetButtonUp(triggerButton))
        {
            //Detach the object from the hand 
            heldObject.transform.SetParent(null);
            heldObject.useGravity = true;
            heldObject.isKinematic = false;

            //Apply a force to the object thrown 
            heldObject.AddForce(transform.forward * throwImpulse);
        }
    }
} 