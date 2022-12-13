using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    private static AudioManager audioManager;
    private static GameObject[] arrRooms;
    [SerializeField]
    private GameObject roomPrefab;

    void Awake()
    {
        int i, nbrRooms = 1;

        audioManager = FindObjectOfType<AudioManager>();

        arrRooms = new GameObject[nbrRooms];
        for (i = 0; i < arrRooms.Length; ++i)
            arrRooms[i] = Instantiate(roomPrefab) as GameObject;
    }

    void Start()
    {
        audioManager.Play("Theme");
    }
}
