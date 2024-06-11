using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManipulator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextUI;

    // Update is called once per frame
    void Update()
    {
        TextUI.text = WaveScript.GlobalMsg; 

    }
}
