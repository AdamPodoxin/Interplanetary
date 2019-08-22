using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityObject : MonoBehaviour
{
    public Rigidbody2D rb;

    private GravityObject[] gravityObjects;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gravityObjects = FindObjectsOfType<GravityObject>();
    }

    private void FixedUpdate()
    {
        foreach (GravityObject gravityObject in gravityObjects)
        {
            if (gravityObject != this)
                ApplyGravity(gravityObject);
        }
    }

    private void ApplyGravity(GravityObject objectToAttract)
    {
        Rigidbody2D rbToAttract = objectToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float squareDistance = direction.sqrMagnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / squareDistance;
        Vector2 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
