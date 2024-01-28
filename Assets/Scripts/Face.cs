using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public float constantMoveDown = 0.75f;
    public float downLimitY = -1.7f;
    public ScoreManager scoreManager;

    private bool downWasPressed = false;

    void Update()
    {
        if (!scoreManager.isRunning) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            downWasPressed = true;
            GetComponent<Animation>().Play();
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
