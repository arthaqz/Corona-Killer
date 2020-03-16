using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Hud : MonoBehaviour
{
    private static Hud instance;

    public static Hud Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else instance = this;
    }

    

   
   
}
