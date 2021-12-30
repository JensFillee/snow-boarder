using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Member variables
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boastSpeed = 35f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent = to get component of this GameObject
        rb2d = GetComponent<Rigidbody2D>();

        // FindObjectOfType (only works if there is only one SurfaceEffector2D in the game)
        // A component (ex. a Surface Effector 2D, Crash Detector (script)) is of type itself (SurfaceEffector2D / Crash Detector)
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boastSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
