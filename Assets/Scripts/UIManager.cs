using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static TextMeshProUGUI txtCount;
    private static int count;

    void Awake()
    {
        txtCount = transform.Find("Count Text").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        count = 0;
    }

    public static void UpdateCount()
    {
        ++count;
        txtCount.text = count.ToString();
    }
}
