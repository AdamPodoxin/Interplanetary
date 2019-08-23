using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    public Rigidbody2D rb;

    public bool attractOthers = true;

    [SerializeField] private List<GravityObject> objectsInRange = new List<GravityObject>();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        foreach (GravityObject gravityObject in objectsInRange)
        {
            ApplyGravity(gravityObject);
        }
    }

    private void ApplyGravity(GravityObject objectToAttract)
    {
        Rigidbody2D rbToAttract = objectToAttract.rb;

        Vector2 direction = rb.position - rbToAttract.position;
        float squareDistance = direction.sqrMagnitude;

        float forceMagnitude = (rb.mass * rbToAttract.mass) / squareDistance;
        Vector2 force = direction.normalized * forceMagnitude * 10;

        rbToAttract.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GravityObject enteredObject = collision.GetComponent<GravityObject>();

        if (enteredObject != null)
            enteredObject.ObjectEnteredRange(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GravityObject exitedObject = collision.GetComponent<GravityObject>();

        if (exitedObject != null)
            exitedObject.ObjectExitedRange(this);
    }

    public void ObjectEnteredRange(GravityObject gravityObject)
    {
        if (attractOthers && !objectsInRange.Contains(gravityObject)) objectsInRange.Add(gravityObject);
    }

    public void ObjectExitedRange(GravityObject gravityObject)
    {
        if (attractOthers) objectsInRange.Remove(gravityObject);
    }
}
