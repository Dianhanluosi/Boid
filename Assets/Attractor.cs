using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody2D rb;

    public int tg;

    private float cd = 1f;
    
    private void FixedUpdate()
    {
        Attractor[] attractors = FindObjectsOfType<Attractor>();
        foreach (Attractor attractor in attractors)
        {
            if (attractor.tg == tg)
            {
                Attract(attractor);
            }
        }

        cd -= Time.deltaTime;
        if (cd <= 0)
        {
            RunAway();

        }
        
        
    }

    void Attract(Attractor objToAttract)
    {
        Rigidbody2D rbToAttract = objToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;

        float distance = direction.magnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass / Mathf.Pow(distance, 2));
        Vector2 force = direction.normalized * forceMagnitude;
        
        rbToAttract.AddForce(force);
    }

    void RunAway( )
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;


        Vector2 direction = mousePosition - rb.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * 50 / Mathf.Pow(distance, 2));
        Vector2 force = direction.normalized * forceMagnitude;

        rb.AddForce(-force);

    }
    
}
