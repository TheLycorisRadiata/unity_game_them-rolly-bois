using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static Rigidbody _rb;
    private static float _speed, _maxSpeed;
    private static float _horizontalInput, _verticalInput;
    private static Vector3 _checkpoint;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _speed = 15f;
        _maxSpeed = 20f;
        _checkpoint = Vector3.zero;
    }

    void FixedUpdate()
    {
        // Move the ball
        _rb.AddForce(new Vector3(_horizontalInput, 0f, _verticalInput) * _speed, ForceMode.Force);

        // Cap the ball's speed
        if (_rb.velocity.magnitude > _maxSpeed)
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;

        if (transform.position.y < -1f)
            RespawnPlayer();
    }

    void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        _horizontalInput = movementVector.x;
        _verticalInput = movementVector.y;
    }

    private void RespawnPlayer()
    {
        transform.position = _checkpoint;
        _rb.velocity = Vector3.zero;
    }
}
