using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroatDeath : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Animation foodFaceAnimation;
    public AudioSource foodFaceAudioSource;

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
        if (collision.gameObject == null)
        {
            return;
        }
        Debug.Log("Collision in throat with: " + collision.gameObject.name);
        FoodAffectOnPlayer food_affect = collision.gameObject.GetComponent<FoodAffectOnPlayer>();
        scoreManager.AddHealth(-food_affect.score_addition);
        foodFaceAnimation.Play("Gag");
        foodFaceAudioSource.Play();
        // Destroy the object to reduce waste!
        Destroy(collision.gameObject, 0.1f);        
    }
}