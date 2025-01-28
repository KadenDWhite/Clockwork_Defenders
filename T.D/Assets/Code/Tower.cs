using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;

    public float fireRate;
    public float fireCooldown;

    public GameObject projectilePrefab;

    public Transform firePoint;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown < 0f)
        {
            GameObject closestEnemy = FindClosestEnemy();

            if (closestEnemy != null)
            {
                ShootAtEnemy(closestEnemy);
            }

            fireCooldown = fireRate;
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < minDistance && distance <= range)
            {
                closestEnemy = enemy;
                minDistance = distance;
            }
        }
        return closestEnemy;
    }

    void ShootAtEnemy(GameObject enemy)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        projectile.GetComponent<Projectile>().target = enemy.transform;
    }
}
