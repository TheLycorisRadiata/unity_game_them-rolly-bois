using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static int count;

    void Start()
    {
        count = 0;
    }

    public static void UpdateCount()
    {
        ++count;
        Debug.Log(count);
    }
}
