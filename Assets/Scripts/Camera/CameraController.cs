using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static Vector3 _offset;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _offset = transform.position - _player.position;
    }

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}
