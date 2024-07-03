using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Koopa;
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
        Debug.Log(EnemyScript.kills);
        GlobalMsg = "You have " + targetTime.ToString("F2") + " seconds before wave 1 starts!";
        targetTime -= Time.deltaTime;
        switch (Wave)
        {
            case 1:
                Wave1();
                break;

            case 2:
                Debug.Log("Im at wave two!");
                Wave2();
                break;

            case 3:
                Debug.Log("Im at wave three!!");
                Wave3();
                break;
        }
    }

    private void Wave1()
    {
        if (targetTime < 0)
        {
            TMP.SetActive(false);
            Instantiate(prefab, Location, Quaternion.identity);
            if (EnemyScript.kills > 3) // dit is Value + 2 en dan gaat hij naar de volgende wave...?
            {
                Wave++;
            }
            targetTime = 6;
        }
    }

    private void Wave2()
    {
        if (targetTime < 0)
        {
            Instantiate(Koopa, Location, Quaternion.identity);
            Instantiate(Koopa, Location, Quaternion.identity);
            if (EnemyScript.kills > 10) // dit is Value + 2 en dan gaat hij naar de volgende wave...?
            {
                Wave++;
            }
            targetTime = 6;
        }
    }

    private void Wave3()
    {
        if (targetTime < 0)
        {
            Instantiate(prefab, Location, Quaternion.identity);
            Instantiate(Koopa, Location, Quaternion.identity);
            if (EnemyScript.kills > 5) // dit is Value + 2 en dan gaat hij naar de volgende wave...?
            {
                Wave++;
            }
            targetTime = 5;
        }
    }
}