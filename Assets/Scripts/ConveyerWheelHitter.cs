using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWheelHitter : MonoBehaviour
{
    public float nudgeForce = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        if (otherRigidbody != null)
        {
            //// Apply a force to the other object
            //Vector2 forceDirection = collision.contacts[0].point - (Vector2)transform.position;
            //otherRigidbody.AddForce(forceDirection.normalized * hitForce, ForceMode2D.Impulse);
            //Debug.Log("Got hit");

            // Apply a nudge force to the right
            otherRigidbody.AddForce(new Vector2(
                nudgeForce, 0f), ForceMode2D.Impulse);
        }
    }
}


