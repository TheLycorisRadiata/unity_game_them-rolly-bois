using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static AudioManager _audioManager;
    private static GameObject _roomParent, _corridorParent;
    private static GameObject[] _arrRooms, _arrCorridors;
    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private GameObject _corridorPrefab;

    void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();

        GenerateRooms();
        GenerateCorridors();
    }

    private void GenerateRooms()
    {
        int i;
        int nbrRooms = 1;

        _roomParent = new GameObject("Rooms");
        _arrRooms = new GameObject[nbrRooms];

        for (i = 0; i < _arrRooms.Length; ++i)
        {
            _arrRooms[i] = Instantiate(_roomPrefab) as GameObject;
            _arrRooms[i].name = "Room " + i;
            _arrRooms[i].transform.parent = _roomParent.transform;
        }
    }

    private void GenerateCorridors()
    {
        int i;
        int nbrCorridors = 2;

        _corridorParent = new GameObject("Corridors");
        _arrCorridors = new GameObject[nbrCorridors];

        for (i = 0; i < _arrCorridors.Length; ++i)
        {
            _arrCorridors[i] = Instantiate(_corridorPrefab) as GameObject;
            _arrCorridors[i].name = "Corridor " + i;
            _arrCorridors[i].transform.parent = _corridorParent.transform;

            // tmp
            if (i == 0)
                _arrCorridors[i].transform.position = new Vector3(11f, 0, 0);
            else if (i == 1)
                _arrCorridors[i].transform.position = new Vector3(-11f, 0, 0);
        }
    }

    public static void HandleSpaceCompletion(string tag, int index)
    {
        if (index == -1)
            return;

        if (tag == "Room")
        {
            if (_arrRooms[index].transform.Find("Collectibles").childCount == 0)
                _audioManager.Play("SpaceCompleted");
        }
        else
        {
            if (_arrCorridors[index].transform.Find("Collectibles").childCount == 0)
                _audioManager.Play("SpaceCompleted");
        }
    }
}
