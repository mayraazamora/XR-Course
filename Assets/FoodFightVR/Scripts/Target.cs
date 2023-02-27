using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed;
    public float range;
    public FoodFight game;

    private Vector3 initialPosition; 

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Slide target back and fourth
        transform.position = initialPosition + transform.right * Mathf.Sin(Time.time * speed) * range;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Let the game know the target was hit
        game.OnTargetHit();

        //Destroy target 
        Destroy(gameObject);
    }

}
