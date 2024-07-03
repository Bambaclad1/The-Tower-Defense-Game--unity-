using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int HP = 5; // Instance variable for health
    public static int kills = 0;

    private void Update()
    {
        //Debug.Log($"{gameObject.name} HP: {HP}"); 
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            godie();
        }
    }

    private void godie()
    {
        kills++;
        Money.coins++;
        Destroy(gameObject);
    }
}
