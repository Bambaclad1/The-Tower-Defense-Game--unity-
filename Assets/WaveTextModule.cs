using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveTextModule : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextUI;
    private string waveStringValue = "null";

    // Update is called once per frame
    private void Start()
    {
    }
    void Update()
    {
        waveStringValue = WaveScript.Wave.ToString();
        TextUI.text = waveStringValue;

    }
}
