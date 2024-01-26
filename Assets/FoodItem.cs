using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 0f;
    public string keyCode = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void drop() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyCode == "Q" && Input.GetKeyDown(KeyCode.Q))
        {
            drop();    
        }
        if (keyCode == "W" && Input.GetKeyDown(KeyCode.W))
        {
            drop();    
        }
        if (keyCode == "E" && Input.GetKeyDown(KeyCode.E))
        {
            drop();    
        }
        if (keyCode == "R" && Input.GetKeyDown(KeyCode.R))
        {
            drop();    
        }
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision collision)
    {
        moveSpeed = 1f;
    }
}
