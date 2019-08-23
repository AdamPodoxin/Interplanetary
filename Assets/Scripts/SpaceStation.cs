﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spaceship Dock"))
        {
            Transform spaceship = collision.transform.parent;
            Destroy(spaceship.GetComponent<Rigidbody2D>());
            spaceship.GetComponent<Spaceship>().inControl = false;
            spaceship.SetParent(transform);

            GetComponent<Orbit>().enabled = false;
            GetComponent<Spaceship>().inControl = true;

            Camera cam = Camera.main;
            cam.orthographicSize = transform.lossyScale.x * transform.lossyScale.y / 30f;
            cam.GetComponent<CameraMovement>().target = transform;
        }
    }
}