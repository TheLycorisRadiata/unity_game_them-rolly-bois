using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI txtCount;
	public GameObject objWinText;
    private static float xAxis, zAxis;
    private static Rigidbody rb;
    private static Transform coinParent;
    private static int count;
    private static int maxCount;

    void Start()
    {
        objWinText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        coinParent = GameObject.FindGameObjectWithTag("CoinParent").transform;
        count = 0;
        maxCount = coinParent.childCount;
        txtCount.text = "Count: " + count.ToString() + "/" + maxCount.ToString();
    }

    void Update()
    {
        // "Use Physical Keys" enabled
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(xAxis, 0, zAxis));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.transform.parent = null;
            Destroy(other.gameObject);
            ++count;
            txtCount.text = "Count: " + count.ToString() + "/" + maxCount.ToString();
            if (coinParent.childCount == 0)
                objWinText.SetActive(true);
        }
    }
}
