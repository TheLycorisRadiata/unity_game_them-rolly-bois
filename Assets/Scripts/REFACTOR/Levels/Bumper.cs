using UnityEngine;

public class Bumper : MonoBehaviour
{
    private static float _bounceAmount = 200f;
    [field: SerializeField] public bool IsActivated { get; private set; }
    [SerializeField] private Material _activatedMaterial, _deactivatedMaterial;
    private Renderer _rendererComponent;

    private void Awake()
    {
        _rendererComponent = GetComponent<Renderer>();
        SetActivationMaterial();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRb;
        Vector3 bounceDirection;

        if (IsActivated && other.CompareTag("Player"))
        {
            otherRb = other.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                bounceDirection = -otherRb.velocity;
                otherRb.AddForce(bounceDirection * _bounceAmount);
            }
        }
    }

    // Unused for now
    public void SwitchActivation()
    {
        IsActivated = !IsActivated;
        SetActivationMaterial();
    }

    private void SetActivationMaterial()
    {
        _rendererComponent.material = IsActivated ? _activatedMaterial : _deactivatedMaterial;
    }
}
