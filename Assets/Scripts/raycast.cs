using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public GameObject prefab;
    bool mayspawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mayspawn = true;
        if (Input.GetKeyDown("1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                if (hit.collider.tag == "MayBuild")
                {
                    if (hit.collider.tag == "Tower")
                    {
                        mayspawn = false;
                    }
                    if (mayspawn)
                    {
                        Vector3 spawnPosition = new Vector3(transform.position.x, 0, transform.position.z);
                        Instantiate(prefab, spawnPosition, Quaternion.identity);
                    }


                }
            }
        }
        print(mayspawn);
    }
}
