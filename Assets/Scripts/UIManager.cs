using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static AudioManager audioManager;
    private static GameObject objWinText;
    private static TextMeshProUGUI txtCount;
    private static int count;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        objWinText = transform.Find("Win Text").gameObject;
        txtCount = transform.Find("Count Text").GetComponent<TextMeshProUGUI>();
        objWinText.SetActive(false);
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

    public static void DisplayVictoryMessage()
    {
        objWinText.SetActive(true);
        audioManager.Play("Victory");
    }
}
