using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinIdleAnimation : MonoBehaviour
{
    private static float degreesPerSec;
    private static float amplitude;
    private static float frequency;
    Vector3 positionOffset;
    Vector3 tempPosition;

    void Start()
    {
        degreesPerSec = 30f;
        amplitude = 0.25f;
        frequency = 0.8f;
        positionOffset = transform.position;
        positionOffset.y += 0.25f;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSec, 0f), Space.World);
        tempPosition = positionOffset;
        tempPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPosition;
    }
}
