using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject objWinText;
    public TextMeshProUGUI txtCount;
    private static Transform coinParent;
    private static AudioManager audioManager;
    private static int count;
    private static float speed;
    private static float xAxis, zAxis;

    void Awake()
    {
        objWinText.SetActive(false);
        coinParent = GameObject.FindGameObjectWithTag("CoinParent").transform;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        count = 0;
        txtCount.text = count.ToString();
        speed = 5f;
        audioManager.Play("Theme");
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
            txtCount.text = count.ToString();
            if (coinParent.childCount == 0)
            {
                objWinText.SetActive(true);
                audioManager.Play("Victory");
            }
        }
    }
}
