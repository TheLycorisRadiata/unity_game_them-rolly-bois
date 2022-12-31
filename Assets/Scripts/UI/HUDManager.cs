using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] numberPrefabs;
    private static Transform tfAmount;
    private static int count;
    
    void Awake()
    {
        tfAmount = GameObject.Find("Main Camera").transform.Find("HUD Canvas").Find("Coin Counter").Find("Amount");
        InstantiateNumber(0, tfAmount.position);
    }

    void Start()
    {
        count = 0;
    }

    public void UpdateCount()
    {
        char[] tmp;
        int i;
        // For the loop
        Vector3 pos;
        int nbr;

        ++count;
        tmp = count.ToString().ToCharArray();

        for (i = 0; i < tfAmount.childCount; ++i)
            Destroy(tfAmount.GetChild(i).gameObject);

        for (i = 0; i < tmp.Length; ++i)
        {
            nbr = (int)Char.GetNumericValue(tmp[i]);
            pos = tfAmount.position;
            pos.x += i * 2f;
            InstantiateNumber(nbr, pos);
        }
    }

    void InstantiateNumber(int value, Vector3 pos)
    {
        GameObject go = Instantiate(numberPrefabs[value], pos, Quaternion.Euler(0f, 180f, 0f));
        go.transform.localScale = new Vector3(6f, 6f, 6f);
        go.layer = tfAmount.gameObject.layer;
        go.transform.parent = tfAmount;
    }
}
