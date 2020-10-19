using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private float gravityStrength = 9.8f;
    // 1 ~ 6 for each direction, starting from right up diagonal, counterclockwise
    private int gravityDirection;
    public int GravityDirection
    {
        get { return gravityDirection; }
        set
        {
            gravityDirection = value;
            float direction = Mathf.PI * (value * 2 - 1) / 6;
            Physics2D.gravity = new Vector2(Mathf.Cos(direction), Mathf.Sin(direction)) * gravityStrength;
        }
    }
    private Regex rg = new Regex(@"^[1-6]"); // number from 1 to 6

    private void Update()
    {
        print(Physics2D.gravity);
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            if (rg.IsMatch(keyPressed))
            {
                GravityDirection = Int32.Parse(keyPressed);
            }
        }
    }
}
