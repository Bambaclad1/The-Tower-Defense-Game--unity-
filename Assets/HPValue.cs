using TMPro;
using UnityEngine;

public class HPValue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpUI;

    private void Update()
    {
        hpUI.text = PathEnd.GameHP.ToString();
    }
}