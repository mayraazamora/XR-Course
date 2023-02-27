using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotationSpeedPerSecond;

    void Update()
    {
        float deltaTime = Time.deltaTime;
        //Rotate earth on the Y axis 
        transform.Rotate(0, RotationSpeedPerSecond * deltaTime, 0);
    }
}