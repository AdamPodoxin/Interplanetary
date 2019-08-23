using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public Camera cam;

    public Material skyMaterial;

    private void Start()
    {
        cam = Camera.main;
        ChangeOrthoSize(5);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10), 10 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, 10 * Time.deltaTime);
        }
    }

    public void ChangeOrthoSize(float size)
    {
        cam.orthographicSize = size;
        skyMaterial.SetTextureScale("_MainTex", new Vector2(1000f / (size / 8f), 1000f / (size / 8f)));
    }
}
