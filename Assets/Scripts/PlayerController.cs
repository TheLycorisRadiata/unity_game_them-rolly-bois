using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static float x_axis, z_axis;
    private static Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // "Use Physical Keys" enabled
        x_axis = Input.GetAxis("Horizontal");
        z_axis = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(x_axis, 0, z_axis));
    }
}
