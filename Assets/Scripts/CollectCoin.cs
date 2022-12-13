using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private static AudioManager audioManager;
    private static GameObject collectibleParent;
    
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        collectibleParent = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.Play("CoinCollection");
            transform.parent = null;
            Destroy(gameObject);
            UIManager.UpdateCount();

            if (collectibleParent.transform.childCount == 0)
                UIManager.DisplayVictoryMessage();
        }
    }
}
