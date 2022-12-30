using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;
    private GameObject collectibleChildren;
    private GameObject groundChild;
    private GameObject[] arrCoins;
    private int minCoinAmount, maxCoinAmount;
    public int coinAmount;

    void Awake()
    {
        groundChild = transform.Find("Ground").gameObject;
        collectibleChildren = transform.Find("Collectibles").gameObject;
    }

    void Start()
    {
        PopulateSpace();
    }

    private void PopulateSpace()
    {
        int i;
        float coinScale = 0.5f, coinHeight = coinPrefab.transform.position.y;
        float xMin, xMax, zMin, zMax;

        if (gameObject.tag == "Room")
        {
            // Default Unity plane (10x10)
            xMin = -5f + coinScale;
            xMax = 5f - coinScale;
            zMin = -5f + coinScale;
            zMax = 5f - coinScale;

            minCoinAmount = 1;
            maxCoinAmount = 12;
        }
        else if (gameObject.tag == "Corridor")
        {
            // Based upon the default Unity plane (2x10)
            xMin = -1f + coinScale;
            xMax = 1f - coinScale;
            zMin = -5f + coinScale;
            zMax = 5f - coinScale;

            minCoinAmount = 1;
            maxCoinAmount = 3;
        }
        else
            return;

        coinAmount = (int)Random.Range(minCoinAmount, maxCoinAmount);

        arrCoins = new GameObject[coinAmount];
        for (i = 0; i < arrCoins.Length; ++i)
        {
            arrCoins[i] = Instantiate(coinPrefab) as GameObject;
            arrCoins[i].transform.parent = collectibleChildren.transform;
            // The coin scale has been taken into account as not to have the coin placed within walls
            arrCoins[i].transform.localPosition = new Vector3(Random.Range(xMin, xMax), coinHeight, Random.Range(zMin, zMax));
        }
    }
}
