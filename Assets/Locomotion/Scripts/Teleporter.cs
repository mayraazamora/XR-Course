using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public string thumbstickInputName;
    public float thumbstickThreshold = -0.5f;
    public LineRenderer beam;
    public float range;
    public Color validColour;
    public Color invalidColour;
    public GameObject teleportInicator;
    public Transform player;

    private bool hasValidTeleportTarget;

    private void Start()
    {
        // Hide the beam initially 
        SetBeamVisible(false);
    }

    void Update()
    {
        // If the thumbstick is pressed forward 
        if(Input.GetAxis(thumbstickInputName)< thumbstickThreshold)
        {
            // Show the teleportation beam
            SetBeamVisible(true);

            // Extend the beam to it's maximum range
            SetBeamEndPoint(transform.position + transform.forward * range);

            // Check if the beam hit something
            if(Physics.Raycast(transform.position, transform.forward, out var hit, range))
            {
                // Update the beam's endpoint to the point in space it hit
                SetBeamEndPoint(hit.point);

                // If the object hit a valid teleport target
                if (IsValidTeleportTarget(hit.collider.gameObject))
                {
                    // Set the beam to be valid
                    SetTeleportValid(true);

                    // Set the position of the teleport indicator
                    teleportInicator.transform.position = hit.point + Vector3.up * 0.001f; 
                }
                // If the object we hit is an invalid teleport target 
                else
                {
                    // Set the beam to be invalid
                    SetTeleportValid(false);
                }
            }
            // If we didn't hit anything 
            else
            {
                // Set the beam to be invalid
                SetTeleportValid(false);

            }
        }
        // If the thumbstick is released 
        else
        {
            // Hide teleportation beam
            SetBeamVisible(false);

            // Do we have a valid teleport target
            if (hasValidTeleportTarget)
            {
                // Teleport the player there
                player.position = teleportInicator.transform.position;

                // Reset the teleport 
                SetTeleportValid(false); 
            }
        }
    }

    private void SetTeleportValid(bool valid)
    {
        // Set the appropriate color of the beam 
        beam.material.color = valid ? validColour : invalidColour;

        // Show or hide the teleporter indicator as appropriate
        teleportInicator.SetActive(valid);

        // Remember wheter or not we have a valid target
        hasValidTeleportTarget = valid;
    }

    private bool IsValidTeleportTarget(GameObject gameObject)
    {
        return true;
    }

    private void SetBeamEndPoint(Vector3 endPoint)
    {
        // Set the start and end positions of the beam
        beam.SetPosition(0, transform.position);
        beam.SetPosition(1, endPoint);

    }

    private void SetBeamVisible(bool visible)
    {
        // Show or hide beam  
        beam.enabled = visible;
    }
}