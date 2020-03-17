using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private float maxHP;
    [SerializeField] private int damage;
    [SerializeField] private float collisionDistance;
    
    private float sumHP;

    private void Awake()
    {
        sumHP = maxHP;
    }

    private void Update()
    {
        Hit();
    }

    public void TakeDamage(float damage)
    {
        sumHP -= damage;
        IsDead();
    }

    private void IsDead()
    {
        if (sumHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    
    private void Hit()
    {
        var hitInfo = Physics2D.OverlapCircle(transform.position, collisionDistance);
        if (hitInfo.gameObject.CompareTag("Player"))
            hitInfo.transform.parent.gameObject.GetComponent<Player>().TakeDamage(damage);
    }
}
