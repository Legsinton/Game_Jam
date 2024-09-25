using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit_Counter : MonoBehaviour
{
    public static Hit_Counter Instance;

    public Text Hits;

    int AddHits = 0;
    void Start()
    {
        Hits.text = AddHits.ToString() + " Hits";
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddCount()
    {
        AddHits += 1;
        Hits.text = AddHits.ToString() + " Hits";
    }
}
