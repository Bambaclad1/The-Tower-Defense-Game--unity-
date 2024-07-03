using UnityEngine;

public class PathEnd : MonoBehaviour
{
    public static int GameHP = 5;
    public GameObject scaryending;

    private void Start()
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

    private void GameOver()
    {
        scaryending.SetActive(true);
    }
}