using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHit : MonoBehaviour
{
    public float weaponDamage;

    ProjectileController myPC;

    public GameObject explosionEffect;

    // Awake is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<ProjectileController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.AddDamage(weaponDamage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPC.RemoveForce();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            hurtEnemy.AddDamage(weaponDamage);
        }
    }
}
