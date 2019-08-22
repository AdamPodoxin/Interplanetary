using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private float movement;

    private Transform inRangeOf;

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * movement * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRangeOf = collision.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRangeOf = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector2 direction = -(inRangeOf.transform.position - transform.position).normalized;

        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rotationZ - 90), 25f * Time.deltaTime);
    }
}
