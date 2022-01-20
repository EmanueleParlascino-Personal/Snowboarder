using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField] float torqueForce = 1;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    SurfaceEffector2D[] effectors = new SurfaceEffector2D[3];

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        effectors = FindObjectsOfType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void disableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            foreach(SurfaceEffector2D effect in effectors)
            {
                effect.speed = boostSpeed;
            }
        }
        else
        {
            foreach(SurfaceEffector2D effect in effectors)
            {
                effect.speed = baseSpeed;
            }
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueForce);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueForce);
        }
    }
}
