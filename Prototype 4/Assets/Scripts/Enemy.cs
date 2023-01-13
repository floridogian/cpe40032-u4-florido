using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    // Private Variables
    private float speed = 3.0f; // Speed of enemy movement
    private Rigidbody enemyRb; // Variable for Rigidbody of enemy
    private GameObject player; // Variable for player

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // Initialize the variable by getting the enemy's Rigidbody component
        player = GameObject.Find("Player"); // Initialize the variable by finding the player
    }

    // Update is called once per frame
    void Update()
    {
        // The enemy will follow the player by getting the player's position
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        
        // Once the enemy goes out of bound, it will be destroyed
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
