using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIte : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject foodParticlePrefab;
    public AudioSource audioSource;

    private void CreateFoodParticles(Transform foodParticlesTransform, Color food_color)
    {
        GameObject food_particle = Instantiate(foodParticlePrefab, foodParticlesTransform.position, Quaternion.identity);
        var food_particle_system = food_particle.GetComponent<ParticleSystem>();
        var main_module = food_particle_system.main;
        main_module.startColor = food_color;
    }

    private void BiteAffect(Transform biteLocation, Color food_color)
    {
        CreateFoodParticles(biteLocation, food_color);
        audioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        FoodAffectOnPlayer food_affect =
            collision.gameObject.GetComponent<FoodAffectOnPlayer>();
        scoreManager.AddScore(food_affect.score_addition);
        Debug.Log("Bit: " + collision.gameObject.name +
            " with score: " + food_affect.score_addition);
        BiteAffect(collision.transform, food_affect.food_color);
        GameObject.Destroy(collision.gameObject);
    }
}
