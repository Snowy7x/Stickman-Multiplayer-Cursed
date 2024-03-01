using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float targetRotation;
    private Rigidbody2D rb;
    public float force;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        //rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, Time.deltaTime * force));
        // rotate towards target rotation
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, Time.deltaTime * force));
    }
}
