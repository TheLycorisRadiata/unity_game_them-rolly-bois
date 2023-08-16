using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _numberPrefabs;
    private static Transform _tfAmount;
    private static int _count;
    
    private void Awake()
    {
        _tfAmount = GameObject.Find("Main Camera").transform.Find("HUD Canvas").Find("Coin Counter").Find("Amount");
        InstantiateNumber(0, _tfAmount.position);
    }

    private void Start()
    {
        _count = 0;
    }

    public void UpdateCount()
    {
        char[] tmp;
        int i;
        // For the loop
        Vector3 pos;
        int nbr;

        ++_count;
        tmp = _count.ToString().ToCharArray();

        for (i = 0; i < _tfAmount.childCount; ++i)
            Destroy(_tfAmount.GetChild(i).gameObject);

        for (i = 0; i < tmp.Length; ++i)
        {
            nbr = (int)char.GetNumericValue(tmp[i]);
            pos = _tfAmount.position;
            pos.x += i * 2f;
            InstantiateNumber(nbr, pos);
        }
    }

    private void InstantiateNumber(int value, Vector3 pos)
    {
        GameObject go = Instantiate(_numberPrefabs[value], pos, Quaternion.Euler(0f, 180f, 0f));
        go.transform.localScale = new Vector3(6f, 6f, 6f);
        go.layer = _tfAmount.gameObject.layer;
        go.transform.parent = _tfAmount;
    }
}
