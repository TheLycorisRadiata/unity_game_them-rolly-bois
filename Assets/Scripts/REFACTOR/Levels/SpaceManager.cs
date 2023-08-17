using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    private GameObject _collectibleChildren;
    private GameObject _groundChild;
    private GameObject[] _arrCoins;
    private int _minCoinAmount, _maxCoinAmount;
    public int CoinAmount;

    private void Awake()
    {
        _groundChild = transform.Find("Ground").gameObject;
        _collectibleChildren = transform.Find("Collectibles").gameObject;
    }

    private void Start()
    {
        PopulateSpace();
    }

    private void PopulateSpace()
    {
        int i;
        float coinScale = 0.5f, coinHeight = _coinPrefab.transform.position.y;
        float xMin, xMax, zMin, zMax;

        if (gameObject.tag == "Room")
        {
            // Default Unity plane (10x10)
            xMin = -5f + coinScale;
            xMax = 5f - coinScale;
            zMin = -5f + coinScale;
            zMax = 5f - coinScale;

            _minCoinAmount = 1;
            _maxCoinAmount = 12;
        }
        else if (gameObject.tag == "Corridor")
        {
            // Based upon the default Unity plane (2x10)
            xMin = -1f + coinScale;
            xMax = 1f - coinScale;
            zMin = -5f + coinScale;
            zMax = 5f - coinScale;

            _minCoinAmount = 1;
            _maxCoinAmount = 3;
        }
        else
            return;

        CoinAmount = (int)Random.Range(_minCoinAmount, _maxCoinAmount);

        _arrCoins = new GameObject[CoinAmount];
        for (i = 0; i < _arrCoins.Length; ++i)
        {
            _arrCoins[i] = Instantiate(_coinPrefab) as GameObject;
            _arrCoins[i].transform.parent = _collectibleChildren.transform;
            // The coin scale has been taken into account as not to have the coin placed within walls
            _arrCoins[i].transform.localPosition = new Vector3(Random.Range(xMin, xMax), coinHeight, Random.Range(zMin, zMax));
        }
    }
}
