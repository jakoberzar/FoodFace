using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropper : MonoBehaviour
{
    public string keyCode = "";
    
    public GameObject current_food;
    public List<GameObject> foodPrefabs;
    public float waitBetweenRespawns = 3.0f;
    public Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = current_food.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool drop_it = false;
        if ((keyCode == "Q" && Input.GetKeyDown(KeyCode.Q)) ||
            (keyCode == "W" && Input.GetKeyDown(KeyCode.W)) ||
            (keyCode == "E" && Input.GetKeyDown(KeyCode.E)) ||
            (keyCode == "R" && Input.GetKeyDown(KeyCode.R)))
        {
            drop_it = true;
        }
        if (drop_it)
        {
            current_food.GetComponent<FoodBehaviour>().drop();
            StartCoroutine(DelayedClone());
        }
    }

    IEnumerator DelayedClone()
    {
        GameObject food_prefab = foodPrefabs[Random.Range(0, foodPrefabs.Count)];
        yield return new WaitForSeconds(waitBetweenRespawns);
        current_food = Instantiate(food_prefab, initialPos, transform.rotation);
        current_food.GetComponent<FoodBehaviour>().isDropped = false;
        current_food.GetComponent<Rigidbody2D>().gravityScale = 0f;
    }
}
