using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private static AudioManager audioManager;
    private static HUDManager hud;
    private string spaceTag;
    private int spaceIndex;
    
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        hud = GameObject.Find("Main Camera").transform.Find("HUD Canvas").GetComponent<HUDManager>();
    }

    void Start()
    {
        Transform t = transform;
        GameObject spaceParent = null;
        spaceTag = "";
        spaceIndex = -1;
        while (t.parent != null)
        {
            if (t.parent.tag == "Room" || t.parent.tag == "Corridor")
            {
                spaceParent = t.parent.gameObject;
                spaceTag = spaceParent.tag;
                spaceIndex = int.TryParse(spaceParent.name.Split(' ')[1], out int x) ? x : -1;
                break;
            }
            t = t.parent.transform;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.Play("CoinCollected");
            transform.parent = null;
            Destroy(gameObject);
            hud.UpdateCount();

            GameHandler.HandleSpaceCompletion(spaceTag, spaceIndex);
        }
    }
}
