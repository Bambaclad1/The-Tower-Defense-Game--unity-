using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackCooldown = 1.0f; // Time between attacks
    private float attackTimer = 0.0f;
    public int damage;

    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AttackEnemy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && attackTimer <= 0)
        {
            AttackEnemy(other.gameObject);
            attackTimer = attackCooldown; // Reset the attack timer
        }
    }

    void AttackEnemy(GameObject enemy)
    {
        Debug.Log("Attacking enemy: " + enemy.name);

        EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);
        }
    }
}
