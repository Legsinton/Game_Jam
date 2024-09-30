using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit_Counter : MonoBehaviour
{
    public static Hit_Counter Instance;

    public Text Hits;

    int AddHits;
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
    public int GetHitCount() // New method to access hit count
    {
        return AddHits;
    }
}
