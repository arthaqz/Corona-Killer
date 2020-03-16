using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // test
    [SerializeField] private string name;
    [SerializeField] private float maxHP;
    
    private float sumHP;

    private void Awake()
    {
        sumHP = maxHP;
    }


    public void TakeDamage(float damage)
    {
        Debug.Log(name + " has taken " + damage + " damage.");
        sumHP -= damage;
        IsDead();
    }

    private void IsDead()
    {
        if (sumHP <= 0)
        {
            Debug.Log(name + " has died!");
            Destroy(this.gameObject);
        }
    }
}
