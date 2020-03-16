using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float waitTime;
    private bool isEnlarged = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (isEnlarged == false)
            {
                animator.SetTrigger("ScaleUp");
                isEnlarged = true;
                StartCoroutine(ScaleDown());
            }
        }
    }

    private IEnumerator ScaleDown()
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetTrigger("ScaleDown");
        isEnlarged = false;
    }
}
