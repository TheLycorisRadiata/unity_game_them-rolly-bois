using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Transform ball;
    private static float directionalSpeed;
    private static float horizontalInput, verticalInput;

    void Awake()
    {
        ball = transform.GetChild(0);
    }

    void Start()
    {
        directionalSpeed = 6f;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * directionalSpeed * Time.deltaTime;
        transform.Translate(movement);
        ball.Rotate(new Vector3(verticalInput, 0f, -horizontalInput) * directionalSpeed, Space.Self);
    }

    void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        horizontalInput = movementVector.x;
        verticalInput = movementVector.y;
    }
}
