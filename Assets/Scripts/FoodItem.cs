using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    public bool isDropped = false;
    public Vector3 initialPos;

    public void drop()
    {
        Debug.Log("Drop called");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        isDropped = true;
    }
}
