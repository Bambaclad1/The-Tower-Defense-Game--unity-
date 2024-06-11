using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cashUI;
    public static int coins = 10;

    // Update is called once per frame
    void Update()
    {
        cashUI.text = coins.ToString();

    }
}
