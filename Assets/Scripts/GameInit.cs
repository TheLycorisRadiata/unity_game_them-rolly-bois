using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    private static AudioManager audioManager;
    private static GameObject[] arrRooms;
    private static GameObject[] arrCorridors;
    [SerializeField]
    private GameObject roomPrefab;
    [SerializeField]
    private GameObject corridorPrefab;

    void Awake()
    {
        int i, nbrRooms = 1, nbrCorridors = 1;

        audioManager = FindObjectOfType<AudioManager>();

        arrRooms = new GameObject[nbrRooms];
        for (i = 0; i < arrRooms.Length; ++i)
            arrRooms[i] = Instantiate(roomPrefab) as GameObject;

        arrCorridors = new GameObject[nbrCorridors];
        for (i = 0; i < arrCorridors.Length; ++i)
            arrCorridors[i] = Instantiate(corridorPrefab) as GameObject;
    }

    void Start()
    {
        audioManager.Play("Theme");
    }
}
