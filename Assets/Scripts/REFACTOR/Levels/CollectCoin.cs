using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private Sound _coinCollected;
    private static HUDManager _hud;
    private string _spaceTag;
    private int _spaceIndex;
    
    private void Awake()
    {
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
            _coinCollected.Play();
            transform.parent = null;
            Destroy(gameObject);
            _hud.UpdateCount();

            GameHandler.instance.HandleSpaceCompletion(_spaceTag, _spaceIndex);
        }
    }
}
