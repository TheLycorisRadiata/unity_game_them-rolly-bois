using System.Linq;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public static Victory instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        gameObject.SetActive(false);
    }

    private void Start()
    {
        Transform[] ts = gameObject.GetComponentsInChildren<Transform>();
        ts = ts.ToList().OrderBy(e => e.name).ToArray();

        TextGeneration.instance.Print(ts[0], "You win!");
        TextGeneration.instance.Print(ts[1], "Press any key");
        TextGeneration.instance.Print(ts[2], "to restart...");
    }

    public void DisplayVictoryPanel()
    {
        gameObject.SetActive(true);
    }
}
