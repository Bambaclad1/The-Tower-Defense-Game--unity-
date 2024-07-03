using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackCooldown = 1.0f; // Time between attacks
    private float attackTimer = 0.0f;
    public int damage;
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector

    private void Update()
    {
        attackTimer -= Time.deltaTime;
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
}
