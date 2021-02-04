﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamesWalk : MonoBehaviour
{
    
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime, 0f, 0f);
    }
}
