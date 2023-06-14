using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private static Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _player.position;
    }

    void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}
