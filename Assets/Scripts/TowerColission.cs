using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackCooldown = 1.0f; // Time between attacks
    private float attackTimer = 0.0f;
    public int damage;
    public float targetTime = 0.5f;
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector

    private void Update()
    {
        targetTime -= Time.deltaTime;
        attackTimer -= Time.deltaTime;

        if (targetTime < 0f)
        {
            // Stop attacking when targetTime is less than 0 (if needed)
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
            ShootProjectile(other.transform);
            attackTimer = attackCooldown; // Reset the attack timer
        }
    }

    private void ShootProjectile(Transform enemyTransform)
    {
        Vector3 spawnPosition = transform.position; // Adjust if needed
        GameObject projectileInstance = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Projectile projectile = projectileInstance.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Initialize(enemyTransform, damage);
        }
    }

    private void AttackEnemy(GameObject enemy)
    {
        Debug.Log("Attacking enemy: " + enemy.name);
    }
}
