using UnityEngine;

public class Jumper : MonoBehaviour
{
    private static float _bounceAmount = 10f;
    [field: SerializeField] public bool IsActivated { get; private set; }
    [SerializeField] private Material _activatedMaterial, _deactivatedMaterial;
    private Renderer _rendererComponent;

    void Awake()
    {
        _rendererComponent = GetComponent<Renderer>();
        SetActivationMaterial();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRb;

        if (IsActivated && other.CompareTag("Player"))
        {
            otherRb = other.GetComponent<Rigidbody>();
            if (otherRb != null)
                otherRb.velocity = new Vector3(0f, _bounceAmount, 0f);
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
