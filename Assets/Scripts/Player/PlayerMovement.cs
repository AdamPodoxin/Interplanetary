using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private float movement;

    private Transform cam;

    private Transform inRangeOf;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * movement * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inRangeOf = collision.transform;

        if (collision.gameObject.CompareTag("Spaceship"))
        {
            cam.GetComponent<CameraMovement>().target = collision.transform;
            collision.transform.GetComponent<Spaceship>().inControl = true;
            gameObject.SetActive(false);
        }
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
