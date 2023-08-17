using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private static AudioManager _audioManager;
    private static HUDManager _hud;
    private string _spaceTag;
    private int _spaceIndex;
    
    private void Awake()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _hud = GameObject.Find("Main Camera").transform.Find("HUD Canvas").GetComponent<HUDManager>();
    }

    private void Start()
    {
        Transform t = transform;
        GameObject spaceParent = null;
        _spaceTag = "";
        _spaceIndex = -1;
        while (t.parent != null)
        {
            if (t.parent.tag == "Room" || t.parent.tag == "Corridor")
            {
                spaceParent = t.parent.gameObject;
                _spaceTag = spaceParent.tag;
                _spaceIndex = int.TryParse(spaceParent.name.Split(' ')[1], out int x) ? x : -1;
                break;
            }
            t = t.parent.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioManager.Play("CoinCollected");
            transform.parent = null;
            Destroy(gameObject);
            _hud.UpdateCount();

            GameHandler.HandleSpaceCompletion(_spaceTag, _spaceIndex);
        }
    }
}
