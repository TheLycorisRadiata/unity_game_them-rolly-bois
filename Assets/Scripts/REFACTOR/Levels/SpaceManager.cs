using System;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManager : MonoBehaviour
{
    public int CoinAmount;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Sound _spaceCompleted;
    private int _minCoinAmount, _maxCoinAmount;
    private Transform _collectibleChildren;
    private GameObject[] _arrCoins;
    private List<Action> _coinDestructionSubscriptions;

    private void Awake()
    {
        _collectibleChildren = transform.Find("Collectibles");
        _coinDestructionSubscriptions = new List<Action>();
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

        CoinAmount = (int)UnityEngine.Random.Range(_minCoinAmount, _maxCoinAmount);

        _arrCoins = new GameObject[CoinAmount];
        for (i = 0; i < _arrCoins.Length; ++i)
        {
            _arrCoins[i] = Instantiate(_coinPrefab) as GameObject;
            _arrCoins[i].transform.parent = _collectibleChildren;
            // The coin scale has been taken into account as not to have the coin placed within walls
            _arrCoins[i].transform.localPosition = 
                new Vector3(UnityEngine.Random.Range(xMin, xMax), coinHeight, UnityEngine.Random.Range(zMin, zMax));
        }

        foreach (Transform coin in _collectibleChildren)
        {
            Action subscription = () => HandleSpaceCompletion(coin);
            coin.GetComponent<CollectCoin>().OnCoinDestroyed += subscription;
            _coinDestructionSubscriptions.Add(subscription);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from remaining events
        foreach (Transform coin in _collectibleChildren)
        {
            Action subscription = () => HandleSpaceCompletion(coin);
            coin.GetComponent<CollectCoin>().OnCoinDestroyed -= subscription;
        }
        _coinDestructionSubscriptions.Clear();
    }

    private void HandleSpaceCompletion(Transform coin)
    {
        /*
            -1 is because the coin's destruction event is triggered from 
            within the coin's OnDestroy() method. At this time, the coin 
            still exists for a few frames.
        */
        if (_collectibleChildren.childCount - 1 == 0)
            _spaceCompleted.Play();
        
        // Unsubscribe from this coin's event
        Action subscription = () => HandleSpaceCompletion(coin);
        coin.GetComponent<CollectCoin>().OnCoinDestroyed -= subscription;
        _coinDestructionSubscriptions.Remove(subscription);
    }
}
