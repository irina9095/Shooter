using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron_Script : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;

    void Start()
    {
        Rigidbody dron = GetComponent<Rigidbody>();
        dron.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
