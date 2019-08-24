using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public bool inControl = false;

    public float thrust = 100f;
    public float fuel = 1000f;

    private float initialFuel;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialFuel = fuel;
    }

    private void FixedUpdate()
    {
        if (fuel > 0 && inControl)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.up * thrust);
                fuel -= thrust * Time.fixedDeltaTime / 100f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-transform.up * thrust / 5f);
                fuel -= thrust / 500f * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(-rb.velocity.normalized * thrust / 3f);
                fuel -= thrust / 300f * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                rb.rotation -= rb.velocity.magnitude / 100f;
                fuel -= rb.velocity.magnitude / 100f;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.rotation += rb.velocity.magnitude / 100f;
                fuel -= rb.velocity.magnitude / 100f;
            }
        }
    }

    public void FullyFuel()
    {
        fuel = initialFuel;
    }
}
