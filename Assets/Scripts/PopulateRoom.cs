using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;
    private GameObject collectibleChild;
    private GameObject groundChild;
    private GameObject[] arrCoins;
    private int minCoinAmount, maxCoinAmount;
    public int coinAmount;

    void Awake()
    {
        groundChild = transform.Find("Ground").gameObject;
        collectibleChild = transform.Find("Collectibles").gameObject;
    }

    void Start()
    {
        int i;
        float coinScale = 0.5f, coinHeight = coinPrefab.transform.position.y;
        // Default Unity plane
        float xMin = -5f + coinScale, xMax = 5f - coinScale;
        float zMin = -5f + coinScale, zMax = 5f - coinScale;

        minCoinAmount = 1;
        maxCoinAmount = 12;
        coinAmount = (int)Random.Range(minCoinAmount, maxCoinAmount);

        arrCoins = new GameObject[coinAmount];
        for (i = 0; i < arrCoins.Length; ++i)
        {
            arrCoins[i] = Instantiate(coinPrefab) as GameObject;
            arrCoins[i].transform.parent = collectibleChild.transform;
            // The coin scale has been taken into account as not to have the coin placed within walls
            arrCoins[i].transform.position = new Vector3(Random.Range(xMin, xMax), coinHeight, Random.Range(zMin, zMax));
        }
    }
}
