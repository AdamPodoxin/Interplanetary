using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), 10 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 10 * Time.deltaTime);

            //cam.orthographicSize = target.GetComponent<Rigidbody2D>().velocity.magnitude * target.lossyScale.magnitude / 5f + target.lossyScale.magnitude + 5f;
        }
    }
}
