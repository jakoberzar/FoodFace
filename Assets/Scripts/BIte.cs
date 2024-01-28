using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIte : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject foodParticlePrefab;

    private void CreateFoodParticles(Transform foodParticlesTransform)
    {
        Instantiate(foodParticlePrefab, foodParticlesTransform.position, Quaternion.identity);
    }

    private void BiteAffect(Transform biteLocation)
    {
        CreateFoodParticles(biteLocation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        FoodAffectOnPlayer food_affect = collision.gameObject.GetComponent<FoodAffectOnPlayer>();
        scoreManager.AddScore(food_affect.score_addition);
        Debug.Log("Bit: " + collision.gameObject.name +
            " with score: " + food_affect.score_addition);
        BiteAffect(collision.transform);
        GameObject.Destroy(collision.gameObject);
    }
}
