using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 Location;
    internal static int Wave = 1;
    public float targetTime = 10.0f;
    public static string GlobalMsg = "null";
    public GameObject TMP;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        GlobalMsg = "You have " + targetTime.ToString("F2") + " seconds before wave 1 starts!";
        Debug.Log(targetTime);
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
        for (int i = 0; i < 4; i++)
        {
            if (targetTime < 0)
            {
                TMP.SetActive(false);
                Instantiate(prefab, Location, Quaternion.identity);
                targetTime = 5;
            }
        }

        if (EnemyScript.kills == 5)
        {
            targetTime = 20.0f;
            if (targetTime < 0)
            {
                targetTime = 5.0f;
                Wave = 2;
            }
        }
    }
}