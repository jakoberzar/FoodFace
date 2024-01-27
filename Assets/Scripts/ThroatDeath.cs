using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroatDeath : MonoBehaviour
{
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision in throat with: " + collision.gameObject.name);
        FoodAffectOnPlayer food_affect = collision.gameObject.GetComponent<FoodAffectOnPlayer>();
        scoreManager.DecreaseScore(food_affect.score_addition * 2);
        // Destroy the object to reduce waste!
        GameObject.Destroy(collision.gameObject);
    }
}