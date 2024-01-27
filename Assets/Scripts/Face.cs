using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public float constantMoveUp = 0.05f;
    public float upLimitY = 1.3f;
    public float constantMoveDown = 0.75f;
    public float downLimitY = -1.7f;

    private bool downWasPressed = false;

    void Start()
    {
        Vector3 position = transform.position;
        position.y = upLimitY;
        transform.position = position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            downWasPressed = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;

        // Set the new Y position with the added movement amount
        if (downWasPressed && position.y >= downLimitY)
        {
            position.y -= constantMoveDown;
            position.y = Math.Max(downLimitY, position.y);
            downWasPressed = false;
        }

        transform.position = position;
    }

}
