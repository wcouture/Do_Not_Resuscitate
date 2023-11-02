using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : Tower.TowerAction
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private Transform shootPosition;

    [SerializeField]
    private float projectileSpeed = 4;

    [SerializeField]
    private float reloadDelay = 1;

    private bool reloading = false;

    public override void performAction(GameObject enemy)
    {
        if (reloading)
            return;

        StartCoroutine("delayShooting");

        // Shoot projectile towards the enemy
        GameObject shotProjectile = GameObject.Instantiate(projectile, shootPosition);

        Tower mainTower = this.GetComponent<Tower>();

        Vector3 shootDirection = enemy.transform.position - shootPosition.position;
        shootDirection.Normalize();
        shootDirection *= projectileSpeed;

        shotProjectile.GetComponent<Rigidbody2D>().velocity = shootDirection;
    }

    IEnumerator delayShooting()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadDelay);
        reloading = false;
    }

}
