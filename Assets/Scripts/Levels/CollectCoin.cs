using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private static AudioManager audioManager;
    private GameObject spaceParent;
    
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        Transform t = transform;
        spaceParent = null;
        while (t.parent != null)
        {
            if (t.parent.tag == "Room" || t.parent.tag == "Corridor")
            {
                spaceParent = t.parent.gameObject;
                break;
            }
            t = t.parent.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        int spaceIndex = -1;

        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.Play("CoinCollected");
            transform.parent = null;
            Destroy(gameObject);
            UIManager.UpdateCount();

            spaceIndex = int.TryParse(spaceParent.name.Split(' ')[1], out int x) ? x : -1;
            GameHandler.HandleSpaceCompletion(spaceParent.tag, spaceIndex);
        }
    }
}
