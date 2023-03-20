using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    public bool canMove = true;
    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove){
            RotatePlayer();
            RespondToBoost();    
        }
    }

    public void DisableMovement(){
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space)){
            surfaceEffector2D.speed = boostSpeed;
        }else {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
