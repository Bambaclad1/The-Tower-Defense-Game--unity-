using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject prefab;
    private bool mayspawn = true;
    public Camera camera;

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(mayspawn);
        if (Input.GetKeyDown("1"))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("MayBuild"))
                {
                    mayspawn = true;

                    // Check for existing Tower at the hit location
            /*      Collider[] hitColliders = Physics.OverlapSphere(hit.point, 0.5f);
                    foreach (Collider collider in hitColliders)
                    {
                        if (collider.CompareTag("Tower"))
                        {
                            mayspawn = false;
                            break;
                        }
                  }*/

                    if (mayspawn && Money.coins >= 5)
                    {
                        Money.coins -= 5;
                        Vector3 spawnPosition = new Vector3(hit.point.x, 0, hit.point.z); // Use hit point
                        Instantiate(prefab, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}
