using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 Location;
    public static int Wave = 1;
    public float targetTime = 5f;
    public static string GlobalMsg = "null";
    public GameObject TMP;
    public int Enemies = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("wavescript logger, wave = " + Wave);
        GlobalMsg = "You have " + targetTime.ToString("F2") + " seconds before wave 1 starts!";
        targetTime -= Time.deltaTime;
        switch (Wave)
        {
            case 1:
                Wave1();
                break;

            case 2:
                break;

            case 3:
                break;
        }
    }

    private void Wave1()
    {
        for (int i = 0; i < 5; i++)  
        {
            if (targetTime < 0)
            {
                TMP.SetActive(false);
                Instantiate(prefab, Location, Quaternion.identity);
                targetTime = 6;
                if (Enemies > 6)
                {
                    Wave++;
                }
            }
            break;

        }

    }

}