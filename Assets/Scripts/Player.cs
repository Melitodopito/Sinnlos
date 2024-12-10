using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine.UI;


using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;



public class Player: MonoBehaviour
{

    [SerializeField] float movementSpeed = 1f;


    // Colliders and Rigid body
    private BoxCollider2D playerColllider2D;
    private Rigidbody2D playerRigidBody2D;



    void Start()
    {
        playerColllider2D = GetComponent<BoxCollider2D>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX * movementSpeed, inputY * movementSpeed, 0);


        movement *= Time.deltaTime;

        transform.Translate(movement);

    }


    private void PlayerMoves()
    {

        

    }



}
