using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject objWinText;
    public TextMeshProUGUI txtCount;
    private static Transform coinParent;
    private static int count;
    private static int maxCount;

    private static AudioManager audioManager;

    private static float speed;
    private static float xAxis, zAxis;

    void Start()
    {
        objWinText.SetActive(false);
        coinParent = GameObject.FindGameObjectWithTag("CoinParent").transform;
        count = 0;
        maxCount = coinParent.childCount;
        txtCount.text = "Count: " + count.ToString() + "/" + maxCount.ToString();

        audioManager = FindObjectOfType<AudioManager>();

        speed = 5f;
    }

    void Update()
    {
        // "Use Physical Keys" enabled
        xAxis = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * xAxis * speed * Time.deltaTime);
        zAxis = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * zAxis * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            audioManager.Play("CoinCollection");
            other.gameObject.transform.parent = null;
            Destroy(other.gameObject);
            ++count;
            txtCount.text = "Count: " + count.ToString() + "/" + maxCount.ToString();
            if (coinParent.childCount == 0)
            {
                objWinText.SetActive(true);
                audioManager.Play("Victory");
            }
        }
    }
}
