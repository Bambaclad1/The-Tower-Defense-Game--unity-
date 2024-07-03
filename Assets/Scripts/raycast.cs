using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject prefab;
    public GameObject cannon;
    private bool mayspawn = true;
    public Camera camera;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("MayBuild"))
                {
                    mayspawn = true;
                    if (mayspawn && Money.coins >= 5)
                    {
                        Money.coins -= 5;
                        Vector3 spawnPosition = new Vector3(hit.point.x, 0, hit.point.z);
                        Instantiate(prefab, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }

        if (Input.GetKeyDown("2"))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("MayBuild"))
                {
                    mayspawn = true;
                    if (mayspawn && Money.coins >= 5)
                    {
                        Money.coins -= 10;
                        Vector3 spawnPosition = new Vector3(hit.point.x, 0, hit.point.z);
                        Instantiate(cannon, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}
