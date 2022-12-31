using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static Transform ball;
    private static float speed;
    private static float xAxis, zAxis;

    void Awake()
    {
        ball = transform.GetChild(0);
    }

    void Start()
    {
        speed = 6f;
    }

    void Update()
    {
        // "Use Physical Keys" enabled
        xAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * xAxis * speed * Time.deltaTime);
        zAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * zAxis * speed * Time.deltaTime);

        ball.Rotate(zAxis, 0f, -xAxis, Space.Self);
    }
}
