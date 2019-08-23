using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public bool inControl = false;

    public float thrust = 100f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (inControl) rb.AddForce(transform.up * thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (inControl) rb.AddForce(-transform.up * thrust / 5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (inControl) transform.Rotate(Vector3.back * (rb.velocity.magnitude / 100f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (inControl) transform.Rotate(Vector3.forward * (rb.velocity.magnitude / 100f));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (inControl) rb.AddForce(-rb.velocity.normalized * thrust / 3f);
        }
    }
}
