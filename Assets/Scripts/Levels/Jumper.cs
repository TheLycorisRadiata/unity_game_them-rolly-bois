using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    private static float bounceAmount;
    public bool isActivated;
    private Renderer rendererComponent;
    [SerializeField] private Material activatedMaterial, deactivatedMaterial;

    void Awake()
    {
        rendererComponent = GetComponent<Renderer>();
        SetActivationMaterial();
    }

    void Start()
    {
        bounceAmount = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGo = other.gameObject;
        Rigidbody otherRb;

        if (isActivated && otherGo.CompareTag("Player"))
        {
            otherRb = otherGo.GetComponent<Rigidbody>();
            if (otherRb != null)
                otherRb.velocity = new Vector3(0f, bounceAmount, 0f);
        }
    }

    // Unused for now
    public void SwitchActivation()
    {
        isActivated = !isActivated;
        SetActivationMaterial();
    }

    private void SetActivationMaterial()
    {
        if (isActivated)
            rendererComponent.material = activatedMaterial;
        else
            rendererComponent.material = deactivatedMaterial;
    }
}
