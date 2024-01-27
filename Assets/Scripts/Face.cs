using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public float constantMoveUp = 0.05f;
    public float upLimitY = 1.3f;
    private float constantMoveDown = 1.2f;
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
        else if (position.y < upLimitY)
        {
            // TODO: Make it more like a spring
            position.y += constantMoveUp;
            position.y = Math.Min(upLimitY, position.y);
        }

        transform.position = position;
    }

}
