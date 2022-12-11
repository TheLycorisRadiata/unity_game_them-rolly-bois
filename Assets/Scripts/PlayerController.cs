using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static float x_axis, z_axis;
    private static Rigidbody rb;
    private static Transform coin_parent;
    private static int count;
    private static bool has_won;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coin_parent = GameObject.FindGameObjectWithTag("CoinParent").transform;
        count = 0;
        has_won = false;
    }

    void Update()
    {
        // "Use Physical Keys" enabled
        x_axis = Input.GetAxis("Horizontal");
        z_axis = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(x_axis, 0, z_axis));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.transform.parent = null;
            Destroy(other.gameObject);
            ++count;
            if (coin_parent.childCount == 0)
            {
                has_won = true;
                Debug.Log("Victory!");
            }
        }
    }
}
