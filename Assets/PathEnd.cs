using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PathEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public static int GameHP = 2;
    public GameObject scaryending;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameHP--;
            Destroy(collision.gameObject);
        }
        if (GameHP <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        scaryending.SetActive(true);
    }
    
    
}
