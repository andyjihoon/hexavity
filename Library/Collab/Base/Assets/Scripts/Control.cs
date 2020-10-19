using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpSpeed = 15f;

    private bool facingRight = true;

    private Rigidbody2D rb;
    public static Gravity gravity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<Gravity>();
        gravity.DirectionNum = 5;
    }

    private void FixedUpdate()
    {
        // positive: right, negative: left
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime);

        // flip sprite according to direction
        if (Mathf.Abs(horizontalInput) > 0.5f)
        {
            if (horizontalInput > 0.5f && !facingRight)
            {
                Flip();
                facingRight = true;
            }
            else if (horizontalInput < -0.5f && facingRight)
            {
                Flip();
                facingRight = false;
            }
        }
    }

    private Regex rg = new Regex(@"^[1-6]"); // numbers from 1 to 6
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = gravity.Direction * -jumpSpeed;
        }

        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            if (rg.IsMatch(keyPressed))
            {
                gravity.DirectionNum = int.Parse(keyPressed);
                rb.rotation = Mathf.Rad2Deg * gravity.DirectionRadian + 90;
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 newLocalScale = transform.localScale;
        newLocalScale.x *= -1;
        transform.localScale = newLocalScale;
    }
}