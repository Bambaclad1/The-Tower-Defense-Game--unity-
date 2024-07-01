using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public GameObject Enemy;
    public int ATK;
    public static int kills = 0;

    public void Update()
    {
        Debug.Log(Enemy);
    }
    public void TakeDamage(int damage)
    {
        HP = HP - damage;

        if (HP < 0)
        {
            Destroy(Enemy);
            kills++;
            Money.coins++;
        }
    }
}
