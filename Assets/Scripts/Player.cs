﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody;

    private Animator myAnimator; 

    [SerializeField]
    private float movementSpeed; 

    private bool facingRight; 

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        facingRight = true; 

	}
	
	// Update is called once per frame
	void FixedUpdate ()
        {
            float horizontal = Input.GetAxis("Horizontal");

            HandleMovement(horizontal);

        Flip(horizontal);
        }

        private void HandleMovement(float horizontal) 
        {

            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        }

        private void Flip(float horizontal)
        {

            if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
            {
                facingRight = !facingRight;

                Vector3 theScale = transform.localScale;

                theScale.x *= -1;

                transform.localScale = theScale;
            }
    }
}
