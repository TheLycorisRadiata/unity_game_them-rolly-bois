using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody rb;
    private static Transform ball;
    private static float speed, maxSpeed;
    private static float horizontalInput, verticalInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ball = transform.GetChild(0);
    }

    void Start()
    {
        speed = 6f; // For a 60 Hz screen: 0.1f (1/60 * 6)
        maxSpeed = 0.166f;
    }

    void FixedUpdate()
    {
        // Move the ball
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Cap the ball's speed
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

        // Ball animation
        ball.Rotate(new Vector3(verticalInput, 0f, -horizontalInput) * speed, Space.Self);
    }

    void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;
    }
}
