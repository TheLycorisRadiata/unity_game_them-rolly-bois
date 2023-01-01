using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody rb;
    private static float speed, maxSpeed;
    private static float horizontalInput, verticalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        speed = 15f;
        maxSpeed = 20f;
    }

    void FixedUpdate()
    {
        // Move the ball
        rb.AddForce(new Vector3(horizontalInput, 0f, verticalInput) * speed, ForceMode.Force);

        // Cap the ball's speed
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;
    }
}
