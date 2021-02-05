using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Fader fader;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        fader=GetComponentInChildren<Fader>();
        
    }
}
