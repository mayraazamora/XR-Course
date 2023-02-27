using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grabber : MonoBehaviour
{
    public string gripInputName;
    public string triggerInputName;

    private Grabbable touchedObject;
    private Grabbable grabbedObject;

    // Update is called once per frame
    void Update()
    {
        // If the grip button is pressed           
        if (Input.GetButtonDown(gripInputName))    
        {
            // Play the gripped animation
            GetComponent<Animator>().SetBool("Gripped", true);

            // If we're touching something
            if (touchedObject != null)
            {
                // Let the touched object know it was grabbed
                touchedObject.OnGrab(this);

                // Store the new grabbed object 
                grabbedObject = touchedObject;
            }
        }

        // If the grip button is released           
        if (Input.GetButtonUp(gripInputName))    
        {
            // Stop playing the gripped animation
            GetComponent<Animator>().SetBool("Gripped", false);

            // If we have a grabbed object 
            if(grabbedObject != null)
            {
                // Let the grabbed object know it has been dropped
                grabbedObject.OnDrop();

                //Reset the grabbed object
                grabbedObject = null;
            }
        }        

        // If the trigger button is pressed
        if (Input.GetButtonDown(triggerInputName))
        {
            // If we have a grabbed object 
            if (grabbedObject != null)
            {
                // Let the grabbed object know it has been triggerd 
                grabbedObject.OnTriggerStart();
            }
        }

        // If the trigger button is released
        if (Input.GetButtonUp(triggerInputName))
        {
            // If we have a grabbed object 
            if (grabbedObject != null)
            {
                // Let the grabbed object know it has stopped being triggerd 
                grabbedObject.OnTriggerEnd();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we touched is a grabbable object
        Grabbable grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            // Let the object know it was touched
            grabbable.OnTouched(this);

            // Stored the currently touched object 
            touchedObject = grabbable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object we stopped touching is a grabbable object
        Grabbable grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            // Let the object know it is no longer being touched
            grabbable.OnUntouched(this);

            // Reset the currently touched object 
            // TODO: This will need more work when we have lots of objects close together
            touchedObject = null;
        }
    }
}