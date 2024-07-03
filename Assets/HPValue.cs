using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPValue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpUI;

    // Update is called once per frame
    void Update()
    {
        hpUI.text = PathEnd.GameHP.ToString();

    }
}
