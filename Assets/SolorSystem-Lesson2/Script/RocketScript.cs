 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public float turningForce;
    public float engineForce;
    public GameObject engineLight;

    private Rigidbody rigidBody;
    private bool engineOn;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get our mouse controls
        float yaw = Input.GetAxis("Mouse X");
        float pitch = Input.GetAxis("Mouse Y");

        Debug.Log($"Mouse X: {yaw} Mouse Y: {pitch}");

        // Rotate the rocket using the mouse controls

        rigidBody.AddRelativeTorque(
            pitch * turningForce * Time.deltaTime, 
            yaw * turningForce * Time.deltaTime, 
            0f);

        // Turn on the rocket engine when " W " is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            engineOn = true;
            engineLight.SetActive(true);
        }

        // Turn off the rocket engine when " W " is released
        if (Input.GetKeyUp(KeyCode.W))
        {
            engineOn = false;
            engineLight.SetActive(false);
        }

        // If the engine is on
        if (engineOn)
        {
            // Apply engine force   
            Debug.Log(transform.forward * engineForce * Time.deltaTime);
            rigidBody.AddForce(transform.forward * engineForce * Time.deltaTime);
        }

        //If ESC is pressed 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Exit play 

        }
    }
}