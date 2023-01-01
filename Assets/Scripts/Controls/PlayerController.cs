using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody rb;
    private static float speed, maxSpeed;
    private static float horizontalInput, verticalInput;
    private static Vector3 nullVector;
    private static Vector3 checkpoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        speed = 15f;
        maxSpeed = 20f;
        nullVector = new Vector3(0f, 0f, 0f);
        checkpoint = nullVector;
    }

    void FixedUpdate()
    {
        // Move the ball
        rb.AddForce(new Vector3(horizontalInput, 0f, verticalInput) * speed, ForceMode.Force);

        // Cap the ball's speed
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;

        if (transform.position.y < -1f)
            RespawnPlayer();
    }

    void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;
    }

    private void RespawnPlayer()
    {
        transform.position = checkpoint;
        rb.velocity = nullVector;
    }
}
