using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float orbitSpeed = 10f;
    public Vector3 orbitCenter;

    private void FixedUpdate()
    {
        transform.RotateAround(orbitCenter, Vector3.forward, -orbitSpeed * Time.deltaTime / 10f);
    }
}
