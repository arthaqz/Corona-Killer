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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
