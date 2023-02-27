using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownToDestroy : MonoBehaviour
{
    public float lifespan;

    void Update()
    {
        // Decrease the lifespan
        lifespan -= Time.deltaTime;

        // If the lifespan has run out
        if (lifespan <= 0f)
        {
            //Die
            Destroy(gameObject);
        }
    }
}
