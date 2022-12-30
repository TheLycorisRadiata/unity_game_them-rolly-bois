using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static AudioManager audioManager;
    private static GameObject roomParent, corridorParent;
    private static GameObject[] arrRooms, arrCorridors;
    [SerializeField]
    private GameObject roomPrefab;
    [SerializeField]
    private GameObject corridorPrefab;

    void Awake()
    {
        int i, nbrRooms = 1, nbrCorridors = 2;
        audioManager = FindObjectOfType<AudioManager>();

        roomParent = new GameObject("Rooms");
        corridorParent = new GameObject("Corridors");

        arrRooms = new GameObject[nbrRooms];
        for (i = 0; i < arrRooms.Length; ++i)
        {
            arrRooms[i] = Instantiate(roomPrefab) as GameObject;
            arrRooms[i].name = "Room " + i;
            arrRooms[i].transform.parent = roomParent.transform;
        }

        arrCorridors = new GameObject[nbrCorridors];
        for (i = 0; i < arrCorridors.Length; ++i)
        {
            arrCorridors[i] = Instantiate(corridorPrefab) as GameObject;
            arrCorridors[i].name = "Corridor " + i;
            arrCorridors[i].transform.parent = corridorParent.transform;

            // tmp
            if (i == 0)
                arrCorridors[i].transform.position = new Vector3(11f, 0, 0);
            else if (i == 1)
                arrCorridors[i].transform.position = new Vector3(-11f, 0, 0);
        }
    }

    void Start()
    {
        audioManager.Play("Theme");
    }

    public static void HandleSpaceCompletion(string tag, int index)
    {
        if (index == -1)
            return;

        if (tag == "Room")
        {
            if (arrRooms[index].transform.Find("Collectibles").childCount == 0)
                audioManager.Play("SpaceCompleted");
        }
        else
        {
            if (arrCorridors[index].transform.Find("Collectibles").childCount == 0)
                audioManager.Play("SpaceCompleted");
        }
    }
}
