using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private static float _maxSpeed = 20f;
    private float _speed = 15f;
    private float _horizontalInput, _verticalInput;
    private Vector3 _checkpoint = Vector3.zero;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        CapPlayerSpeed();

        if (transform.position.y < -1f)
            RespawnPlayer();
    }

    private void OnMove(InputValue axisValue)
    {
        Vector2 movementVector = axisValue.Get<Vector2>();
        _horizontalInput = movementVector.x;
        _verticalInput = movementVector.y;
    }

    private void MovePlayer()
    {
        _rb.AddForce(new Vector3(_horizontalInput, 0f, _verticalInput) * _speed, ForceMode.Force);
    }

    private void CapPlayerSpeed()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
    }

    private void RespawnPlayer()
    {
        transform.position = _checkpoint;
        _rb.velocity = Vector3.zero;
    }
}
