using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject destroyEffect;
    public LayerMask hittableLayer;
    [SerializeField] private float damage;
    public float speed;
    public float distance;

    private void Start()
    {
        Invoke(nameof(DestroyBullet), GameSettings.BulletLifetime);
        
    }

    private void Update()
    {
         // TODO: Udelat methodu a ne to drzet v updatu
         transform.position += transform.up * speed * Time.deltaTime;
         Hit();
    }

    private void Hit()
    {
        var hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, hittableLayer);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Enemy"))
                hitInfo.collider.transform.GetComponent<Enemy>().TakeDamage(damage);
            
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity, TempParent.Instance.transform);
        Destroy(this.gameObject);
    }
}
