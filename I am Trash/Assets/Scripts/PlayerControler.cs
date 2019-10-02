
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //Freeze rotation
        body.freezeRotation = true;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(horizontal) >= Mathf.Abs(vertical)) {
            body.velocity = new Vector2(horizontal * runSpeed, 0.0f);
        } else {
            body.velocity = new Vector2(0.0f, vertical * runSpeed);
        }
    }
}