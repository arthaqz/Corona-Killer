using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : MonoBehaviour
{
    [SerializeField] private GameObject coronaGermPrefab;
    [SerializeField] private float spitCooldown;
    [SerializeField] private float maxSpits;
    
    private void Start()
    {
        InvokeRepeating(nameof(Spit), 0f, spitCooldown);
    }

    private void Spit()
    {
        
        Instantiate(coronaGermPrefab, transform.position, Quaternion.identity, TempParent.Instance.transform);
        maxSpits++;
    }
}
