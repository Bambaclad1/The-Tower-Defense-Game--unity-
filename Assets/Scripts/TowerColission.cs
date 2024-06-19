using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackCooldown = 1.0f; // Time between attacks
    private float attackTimer = 0.0f;
    public int damage;
    public float targetTime = 0.5f;
    public ParticleSystem particleSystem;

    private List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;

        attackTimer -= Time.deltaTime;

        if (targetTime < 0f)
        {
            particleSystem.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            AttackEnemy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && attackTimer <= 0)
        {
            AttackEnemy(other.gameObject);
            attackTimer = attackCooldown; // Reset the attack timer
        }
    }

    private void AttackEnemy(GameObject enemy)
    {
        Debug.Log("Attacking enemy: " + enemy.name);

        EnemyScript enemyScript = enemy.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            enemyScript.TakeDamage(damage);
        }
    }
}