﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }
}
