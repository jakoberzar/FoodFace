using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
    public float constantMoveUp = 0.5f;
    public float upperLimitY = 0.5f;
    private float moveDown = 1f;
    private float moveDownLimit = -2.2f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        position.y = upperLimitY;
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // Get the current position of the object
        Vector3 position = transform.position;

        // Set the new Y position with the added movement amount
        if (Input.GetKey(KeyCode.Space) && position.y >= moveDownLimit)
        {
            position.y -= moveDown;
            position.y = Math.Max(moveDownLimit, position.y);
        } else if (position.y < upperLimitY)
        {
            position.y += constantMoveUp;
        }

        // Set the object's position to the new position
        transform.position = position;
    }

}
